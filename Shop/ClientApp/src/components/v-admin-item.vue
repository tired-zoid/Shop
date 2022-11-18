<template>
    <div class="v-admin-item">
        <v-card 
            max-width="450"
        >

            
            <div  v-if="!isChangingMode" >

                <v-img
                    class="mx-auto"
                    width= "250px"
                    height= "300px"
                    :src="require('../assets/' + adminProduct.img)"
                />

                <v-card-title> 
                    {{adminProduct.name}}
                </v-card-title>

                <v-card-subtitle>
                    <h3>Price: {{adminProduct.price}}</h3>
                    <h3>Quantity: {{adminProduct.productQuantity}}</h3>
                </v-card-subtitle>

                <v-card-actions>
                    <v-btn v-on:click = "isChangingMode = true">
                        Edit
                    </v-btn>

                    <v-spacer></v-spacer>
                    
                    <v-btn @click="removeProduct(adminProduct)">
                        Delete
                    </v-btn>
                </v-card-actions>
            </div>
            
            <div v-else>
                <v-img
                    class="mx-auto"
                    width= "250px"
                    height= "300px"
                    :src="require('../assets/' + adminProduct.img)"
                />

                <v-file-input
                    label="Product photo"
                    v-model="adminProduct.img"
                />

                <v-card-title> 
                    <input v-model = adminProduct.name />
                </v-card-title>

                <v-card-subtitle>
                    <h3>Price: <input type="number" v-model = adminProduct.price /> </h3>
                    <h3>Quantity: <input type="number" v-model = adminProduct.productQuantity /></h3>

                    <v-btn @click="saveChanges(adminProduct)">
                        Save
                    </v-btn>

                     <v-spacer></v-spacer>
                </v-card-subtitle>
            </div>

        </v-card>
    </div>
</template>

<script>
import { mapActions, mapGetters} from 'vuex'

export default  {
    name: 'v-admin-item',
    data() {
        return {
            isChangingMode: false
        }
    },
    props: {
        adminProduct: {},
    },
    computed: {
        ...mapGetters([
            'PRODUCTS'
        ])
    },
    methods: {
            removeProduct() {
                this.$emit('removeProduct', this.adminProduct)
            },
            saveChanges() {
                this.isChangingMode = false
                this.adminProduct.price = parseInt(this.adminProduct.price)
                this.adminProduct.productQuantity = parseInt(this.adminProduct.productQuantity)
                this.UPDATE_PRODUCT(this.adminProduct)
            },
            ...mapActions([
                'UPDATE_PRODUCT'
            ])
    }
}
</script>

<style scoped>

.v-admin-item {
    padding: 10px;
    margin-bottom: 10px;
    display: inline-block;
}
</style>
