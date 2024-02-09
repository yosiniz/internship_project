<template>
    <div class="header-container">
        <nav class="flex w-full px-2">
            <div class="flex text-xl">
        <div class="fill-current mr-2" height="36" viewBox="0 0 24 24" width="36">
            <a href="https://www.generalmobile.com/tr" target="_blank"><img src="./gm-logo-black-new.png" style="height:30px; width:250px; " /></a>
        </div>
    </div>

            <div class="ml-auto flex items-center">
                <router-link v-if="rol==`admin`" :to="{name:'addbook'}" class="flex bg-gray-700 hover:bg-black text-white px-3 py-1 rounded-sm text-sm items-center mr-2">
                    <svg xmlns="http://www.w3.org/2000/svg" class="fill-current" height="16" viewBox="0 0 24 24" width="16">
                        <path d="M0 0h24v24H0V0z" fill="none" />
                        <path d="M19 13h-6v6h-2v-6H5v-2h6V5h2v6h6v2z" />
                    </svg>
                    <p title="yeni kitap ekle">yeni cihaz</p>
                </router-link>
                <div class="relative group">
                    <button class="w-8 h-8 flex items-center justify-center rounded-md transition-colors duration-500 hover:bg-gray-200 group-focus-within:bg-gray-300">
                        <svg xmlns="http://www.w3.org/2000/svg" height="24" viewBox="0 0 24 24" class="fill-current" width="24">
                            <path d="M0 0h24v24H0V0z" fill="none" />
                            <path d="M12 8c1.1 0 2-.9 2-2s-.9-2-2-2-2 .9-2 2 .9 2 2 2zm0 2c-1.1 0-2 .9-2 2s.9 2 2 2 2-.9 2-2-.9-2-2-2zm0 6c-1.1 0-2 .9-2 2s.9 2 2 2 2-.9 2-2-.9-2-2-2z" />
                        </svg>
                    </button>
                    <nav class="bg-white !z-10 rounded-md shadow-md p-2 w-56 flex flex-col absolute group-focus-within:visible top-full right-0 invisible">

                        <router-link class="mb-2 menu-item" :to="{name:`HomePage`}">
                            <div height="24" class="fill-current mr-1" viewBox="0 0 24 24" width="24">
                                <i style="font-size:larger;" class="fa-solid fa-globe"></i>
                            </div>
                            home
                        </router-link>


                        <!--<router-link class="mb-2 menu-item" :to="{name :`Account`}">
                    <div class="fill-current mr-1" height="24" viewBox="0 0 24 24" width="24">
                        <i style="font-size:larger;" class="fa-solid -star"></i>
                    </div>
                    aktif
                </router-link>-->

                        <a v-on:click="logout" href="#" class="menu-item">
                            <div class="fill-current mr-1" height="24" viewBox="0 0 24 24" width="24">
                                <i style="font-size:larger;" class="fa-solid fa-right-from-bracket"></i>
                            </div>
                            Logout
                        </a>
                    </nav>
                </div>
            </div>
        </nav>
    </div>
</template>
<script>
    import { mapGetters } from 'vuex';
    export default {

        computed: {
            ...mapGetters(["rolne"])
        },

        data() {
            return {

                rol: this.$store.state.rol,
            }
        },
        methods: {
            logout() {
                this.$store.commit("engelle");
                window.location.assign("/log")
                //this.$router.push({ name: "LoginPage" });
            },
            kapatis() {
                this.$store.commit("engelle")
            }
        }
    }
</script>