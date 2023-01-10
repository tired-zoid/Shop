<template>
    <div class="v-catalog-new-item">
        <v-form  @submit.prevent="addNewItem" ref="newItemForm" id="new-item-form" v-model="formValidity">

        <v-row justify-space-between row class="v-new-item-form">    
            <v-col>      
                <v-text-field
                    label="Name"  
                    v-model="name"
                    :rules="newProductRules"
                />

                <v-text-field
                    label="Price"
                    v-model="price"
                    type="number"
                    min="0"
                    :rules="newProductRules"
                />

                <v-select
                    :items="categories"
                    item-text="name"
                    item-value="value"
                    label="Select a category"
                    v-model="category"     
                    :rules="newProductRules"             
                />
                
            </v-col>

            <v-col>
                <v-text-field
                    label="Article"
                    v-model="article"
                    type="number"  
                    :rules="newProductRules"                 
                />

                <v-text-field
                    label="Quantity"
                    v-model="productQuantity"
                    type="number"
                    min="0"
                    :rules="newProductRules"
                />

                <v-file-input
                    label="Attach product photo"
                    @change="onFileSelected"
                    v-model="selectedFile"
                    :rules="newProductRules"
                />
            </v-col>       
        </v-row>

        </v-form>
   <v-btn 
   type="submit" 
   form="new-item-form"
   :disabled="!formValidity"
  
    >Add new product</v-btn>
           
    </div>
</template>

<script>

 import {mapActions} from 'vuex'
 import axios from 'axios'

export default {
    name: "v-catalog-new-item",
    data() {
        return {
            name: null,
            article: null,
            price: null,
            img: null,
            productQuantity: null,
            category: null,

            newProductRules: [
                name => !!name || 'Thia field is required.'
            ],

            categories: [
                { name:'Man', value: 1 },
                { name:'Woman', value: 2 }
            ],
            selectedFile: null,
            flag: true,
            formValidity: false
        }
    },

    methods: {
        addNewItem () {
                // var np = {  name: this.name, 
                //         price: parseInt(this.price), 
                //         img: this.selectedFile.name, 
                //         productQuantity: parseInt(this.productQuantity),
                //         categoryId: parseInt(this.category),
                //         article:  parseInt(this.article) }
            //this.ADD_PRODUCT_TO_API(np)  // загрузку фото и продукта в одном методе         
            this.allLoad()         
            this.resetForm()
        },
        ...mapActions ([
            'ADD_PRODUCT_TO_API',
            'LOAD_IMAGE',
        ]),

        onFileSelected(data) {
           this.selectedFile = data
        },
        imageUpload()  {
            var fd = new FormData()
            fd.append('image', this.selectedFile)
            this.img = this.selectedFile.name
            axios.post(`http://localhost:65071/product/imageload`, fd) 
                .then(response => 
                    console.log(response))
                .catch((error) => {
                    console.log(error)
      }) 
        }, 
        resetForm() {
            this.$refs.newItemForm.reset()
        },

        allLoad() {
            var np = {  name: this.name, 
            price: parseInt(this.price), 
            img: this.selectedFile.name, 
            productQuantity: parseInt(this.productQuantity),
            categoryId: parseInt(this.category),
            article:  parseInt(this.article) }
            var fd = new FormData()
            fd.append('data', JSON.stringify(np));
            // fd.append('name', this.name)
            // fd.append('price', parseInt(this.price))
            // fd.append('img', this.selectedFile.name)
            // fd.append('productQuantity', parseInt(this.productQuantity))
            // fd.append('categoryId', parseInt(this.category))
            // fd.append('article', parseInt(this.article))
            fd.append('image', this.selectedFile)
            
            //var options = { content: fd, np };


            axios({
        method: 'post',
        url: `http://localhost:65071/product/create`,
        data: fd
    }).then(function (response) {
        console.log(response);
    })
    .catch(function (response) {
        console.log(response);
    });
    //         axios.post(`http://localhost:65071/product/create`,  options ) 
    //             .then(response => 
    //                 console.log(response))
    //             .catch((error) => {
    //                 console.log(error)
    //   })
        }
    },
}
</script>

<style>
.v-new-item-form {
    overflow-x: auto;
    flex-wrap: nowrap;
}
.v-text-field {
    margin: 10px;
}

.v-btn {
    margin: 20px;
}

</style>