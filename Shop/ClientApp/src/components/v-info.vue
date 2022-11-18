<template>
    <div class="v-info">
       <h1> Product information </h1>

        <v-info-item/>
    </div>
</template>

<script>
import vInfoItem from './v-info-item.vue'

export default {
    name: "v-info",
    props: [],
    data() {
        return {}
    },
    components: {
        vInfoItem
    }, 
}
</script>

<style>