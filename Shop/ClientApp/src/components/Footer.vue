<template>
        <v-footer   
            dark
            padless
        >
            <v-card
                class="flex"
                flat
                tile
            >
            <v-card-title>
                <v-row>
                    <v-col align="end">
                        <strong> Subsribe us: </strong>    
                    </v-col>

                    <v-col >
                        <v-text-field
                            class="ma-0 pa-0"
                            prepend-icon="mdi-email" 
                            label="Email"
                            v-model="email"
                            :rules="emailRules"                           
                        ></v-text-field>
                    </v-col>

                    <v-col>
                        <v-btn
                            class="ma-0 pa-0"
                            outlined
                            small
                            fab
                            color="white"
                            @click="subscribe(email)"
                        >
                        <v-icon>mdi-bell</v-icon>
                        </v-btn>
                    </v-col>
                </v-row>
        </v-card-title>
         <hr/>
        <v-card-text class="py-10 white--text text-center">
            <h2> 2021 - Shop</h2>
        </v-card-text>
      </v-card>
    </v-footer>      
</template>

<script>
import { mapActions } from 'vuex'
 
export default {
    name: 'TheFooter', 
    data() {
        return {
            email: null,
            emailRules: []
        }
    },
    methods: {
        subscribe(email) {
            var user = new Object();
            user.email = email
            this.ADD_USER_TO_API(user) 
            this.email = ''
        },
        ...mapActions([
            'ADD_USER_TO_API'
        ])
    },
    watch: {
        email: function (mail) { 
            if (mail !== '') {
                this.emailRules = [                 
                    value => value.indexOf('@') !== 0 || 'Email should have a username.',
                    value => value.includes('@') || 'Email should include an @ symbol.', ]
            } else if (mail === '') {
                this.emailRules = []
            }
        }
    }
      
}
</script>

<style scoped>


</style>