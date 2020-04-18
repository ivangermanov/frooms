import L from 'leaflet'

L.Control.Basemaps = L.Control.extend({
  _map: null,
  includes: L.Evented ? L.Evented.prototype : L.Mixin.Event,
  options: {
    position: 'bottomright',
    layers: [] // list of basemap layer objects, first in list is default and added to map with this control
  },
  basemap: null,
  onAdd (map) {
    this._map = map
    const container = L.DomUtil.create('div', 'basemaps leaflet-control closed')

    // disable events
    L.DomEvent.disableClickPropagation(container)
    if (!L.Browser.touch) {
      L.DomEvent.disableScrollPropagation(container)
    }

    this.options.basemaps.forEach(function (d, i) {
      let basemapClass = 'basemap'

      if (i === 0) {
        this.basemap = d
        this._map.addLayer(d)
        basemapClass += ' active alt'
      }

      if (d._url) {
        const url = d._url
        d._map = map
        const basemapNode = L.DomUtil.create('div', null, container)
        const imgNode = L.DomUtil.create('img', null, basemapNode)
        imgNode.origin = 'anonymous'
        imgNode.crossOrigin = 'anonymous'

        if (d.options && d.options.alt) {
          imgNode.title = d.options.alt
        }

        imgNode.onload = () => {
          const canvas = document.createElement('canvas')
          canvas.width = 96
          canvas.height = 96
          const context = canvas.getContext('2d')
          const offsetX = imgNode.width / 5
          const offsetY = imgNode.height / 5

          context.drawImage(imgNode,
            offsetX, offsetY,
            imgNode.width - offsetX, imgNode.height - offsetX,
            0, 0,
            canvas.width, canvas.height)

          context.font = `${canvas.width / 3}pt Roboto`
          context.textAlign = 'center'
          context.textBaseline = 'middle'
          context.fillText(imgNode.title, canvas.width / 2, canvas.height / 2)
          imgNode.onload = null
          imgNode.src = canvas.toDataURL('image/png')

          L.DomUtil.addClass(basemapNode, basemapClass)
        }
        imgNode.src = url

        L.DomEvent.on(
          basemapNode,
          'click',
          function () {
            // intercept open click on mobile devices and show options
            if (this.options.basemaps.length > 2 && L.Browser.mobile) {
              if (L.DomUtil.hasClass(container, 'closed')) {
                L.DomUtil.removeClass(container, 'closed')
                return
              }
            }
            map.removeLayer(this.basemap)
            console.log(d)
            map.setMaxBounds(d._bounds)
            map.addLayer(d)
            d.bringToBack()
            map.fire('baselayerchange', d)
            this.basemap = d

            L.DomUtil.removeClass(container.getElementsByClassName('basemap active alt')[0], 'active')
            L.DomUtil.removeClass(container.getElementsByClassName('basemap alt')[0], 'alt')

            const altIdx = i % this.options.basemaps.length
            L.DomUtil.addClass(container.getElementsByClassName('basemap')[altIdx], 'active alt')

            L.DomUtil.addClass(container, 'closed')
          },
          this
        )
      }
    }, this)

    L.DomEvent.on(
      container,
      'mouseenter',
      function () {
        L.DomUtil.removeClass(container, 'closed')
      },
      this
    )

    L.DomEvent.on(
      container,
      'mouseleave',
      function () {
        L.DomUtil.addClass(container, 'closed')
      },
      this
    )

    this._container = container
    return this._container
  },
  onRemove (map) {
    this.options.basemaps.forEach(function (d) {
      map.removeLayer(d)
    })
  }
})

L.control.basemaps = function (options) {
  return new L.Control.Basemaps(options)
}
