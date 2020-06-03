import L from 'leaflet'
import './editablePopup.css'

// Adding nametag labels to all popup-able leaflet layers
const sourceTypes = ['Layer', 'Circle', 'CircleMarker', 'Marker', 'Polyline', 'Polygon', 'ImageOverlay', 'VideoOverlay', 'SVGOverlay', 'Rectangle', 'LayerGroup', 'FeatureGroup', 'GeoJSON']

sourceTypes.forEach((type) => {
  L[type].include({
    nametag: type.toLowerCase()
  })
})

//  Adding new options to the default options of a popup
L.Popup.mergeOptions({
  removable: false,
  editable: false
})

// Modifying the popup mechanics
L.Popup.include({
  // modifying the _initLayout method to include edit and remove buttons, if those options are enabled
  _initLayout () {
    const prefix = 'leaflet-popup'
    const container = this._container = L.DomUtil.create('div',
      prefix + ' ' + (this.options.className || '') +
         ' leaflet-zoom-animated')

    const wrapper = this._wrapper = L.DomUtil.create('div', prefix + '-content-wrapper', container)
    this._contentNode = L.DomUtil.create('div', prefix + '-content', wrapper)

    L.DomEvent.disableClickPropagation(wrapper)
    L.DomEvent.disableScrollPropagation(this._contentNode)
    L.DomEvent.on(wrapper, 'contextmenu', L.DomEvent.stopPropagation)

    this._tipContainer = L.DomUtil.create('div', prefix + '-tip-container', container)
    this._tip = L.DomUtil.create('div', prefix + '-tip', this._tipContainer)

    if (this.options.closeButton) {
      const closeButton = this._closeButton = L.DomUtil.create('a', prefix + '-close-button', container)
      closeButton.href = '#close'
      closeButton.innerHTML = '&#215;'

      L.DomEvent.on(closeButton, 'click', this._onCloseButtonClick, this)
    }

    let nametag

    if (this.options.nametag) {
      nametag = this.options.nametag
    } else if (this._source) {
      nametag = this._source.nametag
    } else {
      nametag = 'popup'
    }

    if (this.options.removable && !this.options.editable) {
      const userActionButtons = this._userActionButtons = L.DomUtil.create('div', prefix + '-useraction-buttons', wrapper)
      const removeButton = this._removeButton = L.DomUtil.create('a', prefix + '-remove-button', userActionButtons)
      removeButton.href = '#close'
      removeButton.innerHTML = `Remove this ${nametag}`
      this.options.minWidth = 110

      L.DomEvent.on(removeButton, 'click', this._onRemoveButtonClick, this)
    }

    if (this.options.editable && !this.options.removable) {
      const userActionButtons = this._userActionButtons = L.DomUtil.create('div', prefix + '-useraction-buttons', wrapper)
      const editButton = this._editButton = L.DomUtil.create('a', prefix + '-edit-button', userActionButtons)
      editButton.href = '#edit'
      editButton.innerHTML = 'Edit'

      L.DomEvent.on(editButton, 'click', this._onEditButtonClick, this)
    }

    if (this.options.editable && this.options.removable) {
      const userActionButtons = this._userActionButtons = L.DomUtil.create('div', prefix + '-useraction-buttons', wrapper)
      const removeButton = this._removeButton = L.DomUtil.create('a', prefix + '-remove-button', userActionButtons)
      removeButton.href = '#close'
      removeButton.innerHTML = `Remove this ${nametag}`
      const editButton = this._editButton = L.DomUtil.create('a', prefix + '-edit-button', userActionButtons)
      editButton.href = '#edit'
      editButton.innerHTML = 'Edit'
      this.options.minWidth = 160

      L.DomEvent.on(removeButton, 'click', this._onRemoveButtonClick, this)
      L.DomEvent.on(editButton, 'click', this._onEditButtonClick, this)
    }
  },

  _onRemoveButtonClick (e) {
    this._source.remove()
    L.DomEvent.stop(e)
  },

  _onEditButtonClick (e) {
    // Needs to be defined first to capture width before changes are applied
    const inputFieldWidth = this._inputFieldWidth = this._container.offsetWidth - 2 * 19

    this._contentNode.style.display = 'none'
    this._userActionButtons.style.display = 'none'

    const wrapper = this._wrapper
    const editScreen = this._editScreen = L.DomUtil.create('div', 'leaflet-popup-edit-screen', wrapper)
    const inputField = this._inputField = L.DomUtil.create('div', 'leaflet-popup-input', editScreen)
    inputField.setAttribute('contenteditable', 'true')
    inputField.innerHTML = this.getContent()

    //  -----------  Making the input field grow till max width ------- //
    inputField.style.width = inputFieldWidth + 'px'
    const inputFieldDiv = L.DomUtil.get(this._inputField)

    // create invisible div to measure the text width in pixels
    const ruler = L.DomUtil.create('div', 'leaflet-popup-input-ruler', editScreen)

    const thisStandIn = this

    // Padd event listener to the textinput to trigger a check
    this._inputField.addEventListener('keydown', function () {
      // Check to see if the popup is already at its maxWidth
      // and that text doesnt take up whole field
      if (thisStandIn._container.offsetWidth < thisStandIn.options.maxWidth + 38 &&
            thisStandIn._inputFieldWidth + 5 < inputFieldDiv.clientWidth) {
        ruler.innerHTML = inputField.innerHTML

        if (ruler.offsetWidth + 20 > inputFieldDiv.clientWidth) {
          inputField.style.width = thisStandIn._inputField.style.width = ruler.offsetWidth + 10 + 'px'
          thisStandIn.update()
        }
      }
    }, false)

    const inputActions = this._inputActions = L.DomUtil.create('div', 'leaflet-popup-input-actions', editScreen)
    const cancelButton = this._cancelButton = L.DomUtil.create('a', 'leaflet-popup-input-cancel', inputActions)
    cancelButton.href = '#cancel'
    cancelButton.innerHTML = 'Cancel'
    const saveButton = this._saveButton = L.DomUtil.create('a', 'leaflet-popup-input-save', inputActions)
    saveButton.href = '#save'
    saveButton.innerHTML = 'Save'

    L.DomEvent.on(cancelButton, 'click', this._onCancelButtonClick, this)
    L.DomEvent.on(saveButton, 'click', this._onSaveButtonClick, this)

    this.update()
    L.DomEvent.stop(e)
  },

  _onCancelButtonClick (e) {
    L.DomUtil.remove(this._editScreen)
    this._contentNode.style.display = 'block'
    this._userActionButtons.style.display = 'flex'

    this.update()
    L.DomEvent.stop(e)
  },

  _onSaveButtonClick (e) {
    const inputField = this._inputField
    if (inputField.innerHTML.length > 0) {
      this.setContent(inputField.innerHTML)
      this.fire('save', { value: inputField.innerHTML })
    } else {
      alert('Enter something')
    };

    L.DomUtil.remove(this._editScreen)
    this._contentNode.style.display = 'block'
    this._userActionButtons.style.display = 'flex'

    this.update()
    L.DomEvent.stop(e)
  }
})
