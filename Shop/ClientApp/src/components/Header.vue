<template>
    <div>
        <v-app-bar 
            app  
            dark
            absolute>
            <v-btn 
            text
            to="/"
            > 
                <v-icon dark class="mr-2">
                mdi-home
                </v-icon>
                Shop

            </v-btn>        
            <v-spacer/>

            <v-btn 
            v-for="(link, index) in links"
            :key="index"
            text
            :to="link.url"
            >
                {{link.label}}
            </v-btn>
        </v-app-bar>
    </div>
</template>

<script>

export default {
    name: 'TheHeader',
    data: () =>({
       links: [
           {
             label: 'About',
             url: '/about'
           },
           {
             label: 'Admin',
             url: '/admin'
           } 
       ]
    })
}
</script>

<style scoped>

</style>
