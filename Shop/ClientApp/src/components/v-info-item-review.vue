<template>
    <div class="v-info-item-review">
           <h2> Product reviews </h2>
       <v-card
       v-for="(review, index) in REVIEWS"
       :key="index">
       <v-card-subtitle>
         <h3>From: {{review.name}}</h3>
          <h3>Review: {{review.text}}</h3>
          <h3>Date: {{review.date}}</h3>
       </v-card-subtitle>

       </v-card>
    </div>
</template>

<script>
import {mapGetters} from 'vuex'

export default {
    name: "v-info-item-review",
    data() {
        return {
        }
    },
    computed: {
        ...mapGetters([
            'REVIEWS'
        ])
    },
}

</script>

<style>