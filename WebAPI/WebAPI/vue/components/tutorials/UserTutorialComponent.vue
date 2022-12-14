<template>
  <v-dialog
    v-model="dialog"
    :fullscreen="$vuetify.breakpoint.xs"
    max-width="650px"
    persistent
  >
    <v-stepper v-model="e1">
      <v-stepper-header>
        <template v-for="n in steps">
          <v-stepper-step
            :key="`${n}-step`"
            :complete="e1 > n"
            :step="n"
          >
            {{ headers[n - 1] }}
          </v-stepper-step>
          <v-divider
            v-if="n !== steps"
            :key="n"
          />
        </template>
      </v-stepper-header>

      <v-stepper-items>
        <v-stepper-content step="1">
          <span>Tired of waiting until the room becomes available again?  Want to plan everything beforehand? Not familiar with numbers of meeting rooms? </span> </br>
          <span>Then you are at the right place! We are an online platform created to help Fontys students and  employees reserve rooms in the university buildings for meetings, classes, or workshops. </span>
          <v-img
            :src="images.welcome"
            class="mb-4"
            height="350px"
            rel="preload"
          />
          <v-btn
            color="primary"
            @click="nextStep (1)"
          >
            Continue
          </v-btn>

          <v-btn text @click="close">
            Skip tutorial
          </v-btn>
        </v-stepper-content>

        <v-stepper-content step="2">
          <span>To have easier planning, we provide statistics about busiest time slots, days, and buildings.</span>
          <v-row align="center" justify="center">
            <v-img
              :src="images.plan"
              class="mb-4"
              max-height="370px"
              max-width="350px"
            />
          </v-row>

          <v-btn
            color="primary"
            @click="nextStep (2)"
          >
            Continue
          </v-btn>

          <v-btn text @click="close">
            Skip tutorial
          </v-btn>
        </v-stepper-content>

        <v-stepper-content step="3">
          <span>Your journey starts on floor map where you can select rooms to book. First, feel in the information: date, time, campus, etc. Then select available room from map. Green ??? available, red ??? taken.</span>
          <v-img
            :src="images.choose"
            class="mb-4"
          />

          <v-btn
            color="primary"
            @click="nextStep (3)"
          >
            Continue
          </v-btn>

          <v-btn text @click="close">
            Skip tutorial
          </v-btn>
        </v-stepper-content>

        <v-stepper-content step="4">
          <span>Finalize the booking with one button click.</span>
          <v-img
            :src="images.book"
            class="mb-4"
          />

          <v-btn
            color="primary"
            @click="nextStep (4)"
          >
            Continue
          </v-btn>

          <v-btn text @click="close">
            Skip tutorial
          </v-btn>
        </v-stepper-content>

        <v-stepper-content step="5">
          <span>We know people are quite forgetful sometimes, thus you have a list of your reservations, which you can also edit and cancel. Also, we will notify if your notification was successful with the alert.</span>
          <v-img
            :src="images.view"
            class="mb-4"
          />

          <v-btn
            color="primary"
            @click="nextStep (5)"
          >
            Continue
          </v-btn>

          <v-btn text @click="close">
            Skip tutorial
          </v-btn>
        </v-stepper-content>

        <v-stepper-content step="6">
          <span>We hope you have a great booking experience, if not please leave us know <a href="mailto:support@frooms.fontys.nl">support@frooms.fontys.nl</a>!</span>
          <v-row align="center" justify="center">
            <v-img
              :src="images.enjoy"
              class="mb-4"
              max-height="350px"
              max-width="350px"
            />
          </v-row>

          <v-btn
            color="primary"
            @click="close"
          >
            Finish
          </v-btn>
        </v-stepper-content>
      </v-stepper-items>
    </v-stepper>
  </v-dialog>
</template>

<script>

export default {
  data () {
    return {
      e1: 1,
      dialog: true,
      steps: 6,
      headers: ['Welcome', 'Plan', 'Choose', 'Book', 'View', 'Enjoy'],
      images: {
        welcome: require('~/assets/froom_big_logo.png'),
        plan: require('~/assets/plan.png'),
        choose: require('~/assets/choose.png'),
        book: require('~/assets/book.png'),
        view: require('~/assets/view.png'),
        enjoy: require('~/assets/enjoy.png')
      }
    }
  },
  methods: {
    nextStep (n) {
      if (n === this.steps) {
        this.e1 = 1
      } else {
        this.e1 = n + 1
      }
    },
    close () {
      this.dialog = false
      this.$emit('close')
    }
  }
}
</script>
