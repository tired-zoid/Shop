import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    products: [],
    cart: [],
    reviews: [],
    product: [],
    image: []
  },
  mutations: {
    SET_PRODUCTS_TO_STATE: (state, products) => {
      state.products = products;
    }, 
    SET_REVIEWS_TO_STATE: (state, reviews) => {
      state.reviews = reviews;
    },
    SET_CART: (state, product) => {
      if (state.cart.length) {
        let isProductExists = false
        state.cart.map(function (item) {
          if (item.id === product.id) {
            isProductExists = true
            item.quantity++
          }
        })
      
      if (!isProductExists)
      {
        state.cart.push(product)
      }
      }
       else {
        state.cart.push(product)
      }
      
    },
    REMOVE_FROM_CART: (state, index) => {
      state.cart.splice(index, 1)
    },
    INCREMENT: (state, index) => {
      state.cart[index].quantity++
    },
    DECREMENT: (state, index) => {
      if (state.cart[index].quantity > 1) {
        state.cart[index].quantity--
      }
    },
    SET_STATE: (state, product) => {
        state.products.push(product)
    },
    ADD_PRODUCT: (state, product) => {
      state.products.push(product)
    },
    REMOVE_FROM_PRODUCTS: (state, deleteInfo) => {
      let p = state.products.indexOf(deleteInfo.product)
      console.log(p)
      state.products.splice(p, 1)
    },
    SET_PRODUCT_TO_STATE: (state, product) => {
      state.product = product
    },
    getProductById: (state, id) => {
      return state.product = state.products.find(product => product.id === id)
    },
    UPDATE_PRODUCT_IN_STATE:(state, product, index) => {
      state.products[index] = product
    }
  },
  actions: {
    GET_PRODUCTS_FROM_API({commit}, page) {
          return axios.get(`http://localhost:65071/Product/all?PageSize=${page.PageSize}&PageNumber=${page.PageNumber}`, page) 
      .then((products) => {
        commit('SET_PRODUCTS_TO_STATE', products.data);
        return products;
      })
      .catch((error) => {
        console.log(error)
        return error;
      }) 

    },
    GET_SELECTED_PRODUCTS_FROM_API({commit}, filter ) {
        return axios.get(`http://localhost:65071/Product?
      PageSize=${filter.ps}
      &PageNumber=${filter.pn}
      &name=${filter.name}
      &category=${filter.category.trim()}
      &price=${filter.price}`) 
      .then((products) => {
        commit('SET_PRODUCTS_TO_STATE', products.data);
        return products;
      })
      .catch((error) => {
        console.log(error)
        return error;
      }) 
    },
    GET_PRODUCT_REVIEWS_FROM_API({commit}, id) {
        return axios.get(`http://localhost:65071/Review/${id}`) 
      .then((reviews) => {
        commit('SET_REVIEWS_TO_STATE', reviews.data);
        return reviews;
      })
      .catch((error) => {
        console.log(error)
        return error;
      }) 
    },
    GET_PRODUCT_FROM_API({commit}, id) {
        return axios.get(`http://localhost:65071/Product/${id}`) 
      .then((product) => {
        commit('SET_PRODUCT_TO_STATE', product.data);
        return product;
      })
      .catch((error) => {
        console.log(error)
        return error;
      }) 
    },
    ADD_TO_CART({commit}, product) {
      commit('SET_CART', product);
    },
    DELETE_FROM_CART({commit}, index) {
      commit('REMOVE_FROM_CART', index);
    },
    INCREMENT_FROM_CART({commit}, index) {
      commit('INCREMENT', index)
    },
    DECREMENT_FROM_CART({commit}, index) {
      commit('DECREMENT', index)
    },
    ADD_TO_STATE({commit}, product) {
      commit('SET_STATE', product);
    },
    ADD_PRODUCT_TO_API({commit}, product) {
        axios.post('http://localhost:65071/product/create', product) 
      .then((response) => {
        commit('ADD_PRODUCT', response.data)
      })
      .catch((error) => {
        if (error.response) { 
          alert(error.response.data.message)
          console.log(error)
        }
      }) 
    },
    DELETE_FROM_PRODUCTS({commit}, deleteInfo) {
        axios.delete(`http://localhost:65071/product/${deleteInfo.ID}`) 
      .then((resp) => {
        commit('REMOVE_FROM_PRODUCTS', resp.data)
      })
      .catch((error) => {
        console.log(error)
      })
    },
    ADD_USER_TO_API({commit}, user) {
        axios.post(`http://localhost:65071/user`, user) 
      .then(response => 
        commit(console.log(response.data.message)
        ))
      .catch((error) => {
        if (error.response) { 
          alert(error.response.data.message)
          console.log(error)
        }
      }) 
    },
    UPDATE_PRODUCT({commit}, product) {
        axios.put(`http://localhost:65071/product`, product) 
      .then(response => 
        commit('UPDATE_PRODUCT_IN_STATE', response.data))
      .catch((error) => {
        console.log(error)
      }) 
    },

},
  getters: {
    PRODUCTS(state) {
      return state.products;
    },
    CART(state) {
      return state.cart; 
    },
    PRODUCT(state) {
      return state.product; 
    },
    REVIEWS(state) {
      return state.reviews; 
    },
    getProductById: (state) => (id) => {
      return state.products.find(product => product.id === id)
    },
}
});


