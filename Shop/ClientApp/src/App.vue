<template>
  <v-app>
    <the-header/>
    <v-main>
      <v-container>
        <v-main-wrapper> </v-main-wrapper>
      </v-container>
    </v-main>
    <the-footer/>
  </v-app>
</template>

<script>
import vMainWrapper from './components/v-main-wrapper.vue'
import TheHeader from './components/Header.vue'
import TheFooter from './components/Footer.vue'

export default {
  name: "App",
  data() {
    return{
    }
  },
  components: {
     vMainWrapper,
     TheHeader,
     TheFooter,


  },
  methods: {
  },
  computed: {
  },
};
</script>
