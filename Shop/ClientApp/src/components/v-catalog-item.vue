<template>
    <div class="v-catalog-item">


        
        <img 
        class="mx-auto"
        width= "250px"
        height= "300px"
        :src="require('../assets/' + product_data.img)" alt="img">
        <p>{{product_data.name}}</p>
        <p>{{product_data.category}}</p>
        <p>Price: {{product_data.price}}</p>
    
    <v-col class="pl-9">
        <v-btn  
            @click="addToCart"
            >Add to cart</v-btn>
            
        <p class="pl-13" @click="reviewLoad(product_data)"><router-link  
            :to="{name: 'info' }">
            Show more</router-link></p>
    </v-col>


    </div>
</template>

<script>
import {mapActions, mapMutations} from 'vuex'

export default {
    name: "v-catalog-item",
    components: { },
    props: {
        product_data: {
            type: Object,
            default () {
                return {}
            }
        }, 
    },
    methods:
    {
        addToCart () {
            this.$emit('addToCart', this.product_data)
        },
        ...mapMutations([
            'getProductById'
        ]),
        ...mapActions([
            'GET_PRODUCT_REVIEWS_FROM_API'
        ]),
        
        reviewLoad(product_data) {
            this.getProductById(product_data.id)
            this.GET_PRODUCT_REVIEWS_FROM_API(parseInt(product_data.id))
        }
    },
    mounted () {
         this.$set(this.product_data, 'quantity', 1)
    }
}
</script>

<style scoped>
.v-catalog-item {
    flex-basis: 25%;
    box-shadow: 0 0 8px 0 #e0e0e0;
    padding: 16px;
    margin-bottom: 16px;
    display: inline-block;
}
</style>