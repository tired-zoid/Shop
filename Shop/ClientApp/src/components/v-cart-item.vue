<template>
    <div class="v-cart-item">
         <img class="v-cart-item_image" :src="require('../assets/' + cart_item_data.img)" alt="img">
         <div class="v-cart-item-info">
             <p>{{cart_item_data.name}}</p>
             <p>{{cart_item_data.price}}</p>
         </div>
         <div class="v-cart-item_quantity"> 
             <p>Quantity:</p>
                <v-btn @click="decrementItem">-</v-btn> 
                {{cart_item_data.quantity}} 
                <v-btn @click="incrementItem">+</v-btn> 
         </div>
         <v-btn @click="deleteFromCart"> Delete </v-btn>
    </div>
</template>

<script>
export default {
    name: "v-cart-item",
    props: {
        cart_item_data: {
            type: Object,
            default () {
                return {}
            }
        }
    },
    methods: {
        deleteFromCart () {
            this.$emit('deleteFromCart')
        }, 
        decrementItem () {
            this.$emit('decrement')
         },
        incrementItem () {
            this.$emit('increment')
         },
    },
    
    mounted () {
        this.$set(this.cart_item_data, 'quantity', 1)
    },
}
</script>

<style scoped>
.v-cart-item {
    flex-wrap: nowrap;
    justify-content: space-between;
    align-items: center;
    box-shadow: 0 0 8px 0 #e0e0e0;
    padding: 16px;
    margin-bottom: 16px;
    display: inline-block;
}
.v-cart-item_image {
        width: 250px;
        height: 300px;
    }

</style>
