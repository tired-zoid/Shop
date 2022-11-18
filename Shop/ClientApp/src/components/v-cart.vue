<template>
    <div class="v-cart">

        <router-link :to="{name: 'catalog'}">
            <div class="v-catalog_link_to_cart"> Back to catalog </div>
        </router-link>

        <h1> Cart </h1>

        <p v-if="!cart_data.length"> There are no products in cart... </p>

        <vCartItem
        v-for="(item, index) in cart_data"
        :key="item.index"
        :cart_item_data="item"
        @deleteFromCart = "deleteFromCart(index)"
        @increment="increment(index)"
        @decrement="decrement(index)"
        />


        <div>
            <h2 v-if="cart_data.length">Total: {{cartTotalCost}} </h2>
        </div>
    </div>
</template>

<script>
import vCartItem from './v-cart-item.vue'
import {mapActions} from 'vuex'

export default {
    name: "v-cart",
    components: { 
        vCartItem,
    },
    props: {
        cart_data: {
            type: Array,
            default() {
                return []
            }
        }
    },

    computed:{
            fullname: {
                get: function () {
                    return this.firstname + ' ' + this.lastname;
                },
                set: function (newValue) {
                    var names = newValue.split(' ')
                    this.firstname = names[0]
                    this.lastname = names[names.length - 1]
                }
            },
             cartTotalCost () { return this.cart_data.reduce((res, item) => res + item.price * item.quantity, 0)} 
        }, 
    data() {
        return {
        firstname:'Tom', lastname:'Smith',
        }
    },
    methods: {
        deleteFromCart (index) {
            this.DELETE_FROM_CART(index)
        },

        decrement (index) {
            this.DECREMENT_FROM_CART(index)
        },
        
        increment (index) {
            this.INCREMENT_FROM_CART(index)
        },
        ...mapActions ([
            'DELETE_FROM_CART',
            'DECREMENT_FROM_CART',
            'INCREMENT_FROM_CART'
        ])
    }, 
}
</script>

