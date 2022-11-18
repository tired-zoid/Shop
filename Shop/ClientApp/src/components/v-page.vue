<template>
    <div class="v-page">
        <v-row>
            <v-col>
                <v-select
                    @input="onPageChange"
                    v-model="pageInfo.PageSize"
                    :items=[1,2,3,4,5,6,7,8,9,10]
                    label="Products per page:"
                ></v-select>
            </v-col>

            <v-col>
                <v-pagination
                    @input="onPageChange"
                    v-model="pageInfo.PageNumber"
                    :length="5"
                ></v-pagination>
            </v-col>
        </v-row>
    </div>
</template>

<script>

export default {
    name: 'v-page',
    props: {
        pageInfo: {
            type: Object,
            default () {
                return {}
            }
        }
    },
    methods: {
        onPageChange() {
            this.$emit('onPageChange', this.pageInfo)
        }
    }
}
</script>
