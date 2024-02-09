<template>
    
    <div class="flex flex-row">
        <aside class="sidebar">
            <!--<router-link class="sidebar-item" :to="{name:`rol`}">
                roller
            </router-link>-->

            <router-link class="sidebar-item" :to="{name:`kulgor`}">
                kullanicilar
            </router-link>

            <router-link v-if="rol != 'okur'" class="sidebar-item" :to="{name:`kulek`}">
                kullanici ekle
            </router-link>

            <router-link class="sidebar-item" :to="{name:`kategori`}">
                kategoriler
            </router-link>

            <router-link class="sidebar-item" :to="{name: `HomePage`}">
                cihazlar
            </router-link>

        </aside>
    </div>
</template>
<script>
    import { mapGetters } from 'vuex';
    import axios from "axios";
    export default {
                computed: {
            ...mapGetters(["rolne"])
        },
        data() {
            return {
            rol: this.$store.state.rol,
            kat:[]
            }
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/h").then(res => {
                this.kat = res.data

            });
        },
    }
</script>
<style>

</style>