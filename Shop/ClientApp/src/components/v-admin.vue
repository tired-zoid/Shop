<template>
    <div class="v-admin">

        <v-new-item
        />

        <v-admin-item
        v-for="(product, index) in PRODUCTS"
        :key="index"
        :adminProduct="product"
        @removeProduct = 'removeProduct'
        />
    
        <v-page
        :pageInfo="page"
        @onPageChange="onPageChange"
        />

    </div>
</template>

<script>
import {mapActions, mapGetters} from 'vuex'
import vNewItem from './v-new-item.vue'
import vAdminItem from './v-admin-item.vue'
import vPage from './v-page.vue'

export default {
    name: "v-admin",
    components: {
        vNewItem,
        vAdminItem,
        vPage
    },
    props: [],
    data() {
        return {
            deleteInfo: {
                ID: 0,
                product: ''
            },
            page: {
                PageNumber: 1,
                PageSize: 10,
            },
        }
    },
    methods: {
        ...mapActions([
            'GET_PRODUCTS_FROM_API',
            'DELETE_FROM_PRODUCTS'
        ]),

        removeProduct(data) {
            this.deleteInfo.ID = data.id
            this.deleteInfo.product = this.getProductById(data.id)
            this.DELETE_FROM_PRODUCTS(this.deleteInfo)
            window.location.reload();
        },

        onPageChange() {
            this.GET_PRODUCTS_FROM_API(this.page)
        }
    },

     computed: {
        ...mapGetters([
            'PRODUCTS',
            'getProductById'
        ])
    },
    
    mounted() {
           this.GET_PRODUCTS_FROM_API(this.page)
    }
}
</script>

<style>

</style>