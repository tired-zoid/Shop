<template>
    <div class="v-info-item">
         <v-col>
            <v-row>
                <v-card>
                    <v-img
                        width= "250px"
                        height= "300px"
                        :src="require('../assets/' + this.PRODUCT.img)"
                    /> 
                 
                    <v-card-title>
                        {{this.PRODUCT.name}}
                    </v-card-title>

                    <v-card-subtitle>
                        <h3>Price: {{this.PRODUCT.price}}</h3>                      
                    </v-card-subtitle>
                </v-card>
           </v-row> 

            <v-row>
                <v-info-item-review/>
            </v-row>

        </v-col> 
    </div>
</template>

<script>
import {  mapGetters } from 'vuex'
import vInfoItemReview from './v-info-item-review.vue'

export default {
    name: 'v-info-item',
    components: {
        vInfoItemReview
    },
    computed: {
        ...mapGetters([
            'PRODUCT'
        ])
    }
}
</script>
