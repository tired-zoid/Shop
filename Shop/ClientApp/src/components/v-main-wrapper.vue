<template>
    <div class="v-main-wrapper">
        <keep-alive>
            <router-view> </router-view>
        </keep-alive>
    </div>
</template>

<script>

export default {
    name: "v-main-wrapper",
    props: [],
    data() {
        return {
        }
    },
    computed: {},
    methods: {},
    watch: {},
    mounted() {
    }

}
</script>

<style>
.main-wrapper {
    max-width: 900px;
    margin: 0 auto;
}
</style>