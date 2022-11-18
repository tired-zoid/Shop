<template>
    <v-container class="v-catalog">

        <router-link :to="{name: 'cart', params: {cart_data:CART}}">
            <div class="v-catalog_link_to_cart">   
                <v-badge overlap v-if="CART.length > 0">
                        <template v-slot:badge>
                        <span> {{CART.length}} </span>
                        </template>
                    </v-badge>
                <v-icon
                        large
                        color="black"
                        >
                        mdi-cart
                </v-icon>
                </div>
        </router-link>

        <h1> Catalog </h1>

        <div class="v-product-search">
        <v-row align="center">
            <v-col>
                <v-text-field
                    label="Search"
                    v-model="filterParams.name"
                ></v-text-field>
            </v-col>

            <v-col>
                <v-autocomplete
                    :items="categories"
                    label="Select a category"
                    v-model="filterParams.category"
                ></v-autocomplete>
            </v-col>

            <v-col class="mt-10"> 
                <!-- min max value -->
                <v-slider
                aria-placeholder="Price less then"
                    inverse-label
                    thumb-label="always"
                    v-model="filterParams.price"
                    min="0"
                    max="5000"
                    step="100"
                ></v-slider>
            </v-col>

            <v-col>
                <v-text-field
                    v-model="filterParams.price"
                    class="mt-0 pt-0"
                    type="number"
                    label="Price less then"
                  ></v-text-field>
            </v-col>

            <v-col>
                <v-btn @click="dataLoad(filterParams)">
                    search
                </v-btn>

                <v-btn @click="clearFields">
                    clear
                </v-btn>
            </v-col>

        </v-row>
        </div>

        <v-catalog-item
        v-for="(product, index) in PRODUCTS"
        :key="index"
        :product_data="product"
        @addToCart = "addToCart"
        />

        <v-page
        :pageInfo="page"
        @onPageChange="onPageChange"
        />

       <!-- Login Module -->
       <!-- <v-card width="400" class="mx-auto mt-5">
           <v-card-title>
               <h1>Login</h1>
           </v-card-title>

           <v-card-text>
               <v-form>
                    <v-text-field
                    label="Login"
                    prepend-icon="mdi-account-circle"/>
                    <v-text-field
                    :type="showPassword ? 'text' : 'password'"
                    label="Password"
                    prepend-icon="mdi-lock"
                    :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                    @click:append="showPassword = !showPassword"/>                 
               </v-form>
               
           </v-card-text>

           <v-card-actions>
               <v-btn color="success">Login</v-btn>
               <v-spacer></v-spacer>
               <v-btn color="info">Register</v-btn>
           </v-card-actions>
       </v-card> -->

        <!-- <v-data-table
            :headers="headers"
            :items="PRODUCTS"
            :items-per-page="5"
            class="elevation-1"
        ></v-data-table> -->


    </v-container>
</template>

<script>
import vCatalogItem from './v-catalog-item.vue'
import vPage from './v-page.vue'
import {mapActions, mapGetters} from 'vuex'

export default {
    name: "v-catalog",
    components: {
        vCatalogItem,
        vPage
     },
    props: [],
    data() {
        return {
            showPassword: false,
            filterParams: {
                name: '', 
                category: '',
                price: 0,
                type: Object,
                default () {
                    return {}
                }
            },
            categories: ['All', 'Woman', 'Man'],
            page: {
                PageNumber: 1,
                PageSize: 10,
            },
            user: {
                email: ''
            },
             headers: [
          {
            text: 'Product',
            align: 'start',
            sortable: false,
            value: 'name',
          },
          { text: 'Article', value: 'article' },
          { text: 'Price', value: 'price' },
          { text: 'Category', value: 'category' },
          
        ],
        } 
    },
    methods: {
        addToCart (data) {
             this.ADD_TO_CART(data)
        },
        ...mapActions ([
            'GET_PRODUCTS_FROM_API',
            'ADD_TO_CART',
            'GET_SELECTED_PRODUCTS_FROM_API',
            'ADD_USER_TO_API'
        ]),
        subscribe(user) {
            var nu = {  email: user.email }
            this.ADD_USER_TO_API(nu) 
            this.user.email = ''
        },
        onPageChange() {
            this.GET_PRODUCTS_FROM_API(this.page)
        },

        dataLoad() {
            var filter = {
            name: this.filterParams.name,
            category: this.filterParams.category,
            price: this.filterParams.price,
            ps: this.page.PageSize,
            pn: this.page.PageNumber
        }
            this.GET_SELECTED_PRODUCTS_FROM_API(filter)
        },

         clearFields() {
            this.filterParams.name = ''
            this.filterParams.category = ''
            this.filterParams.price = 0
            this.GET_PRODUCTS_FROM_API(this.page)
        },
    },
    computed: {
        ...mapGetters([
            'PRODUCTS',
            'CART'
        ]),
    },
    mounted () {
       this.GET_PRODUCTS_FROM_API(this.page)
    },
}
</script>

<style>
.v-catalog_link_to_cart {
    position: absolute;
    top: 10px;
    right: 10px;
    padding: 16px;
    border: solid #0e0e0e;
}

.v-col {
    margin-top: 10px;
}

.v-badge {
    border-radius: 90px; 
    left: 33px;
    height: 23px;
    z-index: 1;
}
</style>