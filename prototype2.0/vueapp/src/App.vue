<template>
    <router-view></router-view>
    <!--<header class="p-3 bg-dark text-white">
        <div class="container">
            <div class="d-flex flex-wrap align-items-center justify-content-lg-start">
                <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
                    <li>
                        <router-link v-if="!girdimi" class="btn btn-primary" active-class="active" to="/tum">
                            tumu
                        </router-link>
                    </li>
                    &nbsp;
                    <li>
                        <router-link v-if="!girdimi" class="btn btn-primary" active-class="active" to="/filtre">
                            filtre
                        </router-link>
                    </li>
                    &nbsp;
                    <li>
                        <router-link v-if="!girdimi" class="btn btn-primary" active-class="active" to="/ekle">
                            kitap kayidi ekle
                        </router-link>
                    </li>
                    &nbsp;
                    <li>
                        <router-link v-if="!girdimi" class="btn btn-primary" active-class="active" to="/ug">
                            kullanici ekle
                        </router-link>
                    </li>
                    &nbsp;
                    <li>
                        <router-link v-if="!girdimi" class="btn btn-primary" active-class="active" to="/kug">
                            kullanici goruntule
                        </router-link>
                    </li>
                    &nbsp;
                    <li>
                        <router-link v-if="!girdimi" class="btn btn-primary" active-class="active" to="/log">
                            <i class="fa-solid fa-right-to-bracket"></i>
                        </router-link>
                    </li>
                    &nbsp;
                    <li>
                        <div v-if="!girdimi" @click="showAlert" class="btn btn-primary" active-class="active">
                            <i class="fa-solid fa-right-from-bracket"></i>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </header>
    <router-view></router-view>
    <script src="https://kit.fontawesome.com/a62dfaa9d0.js" crossorigin="anonymous"></script>-->

</template>
<script>
//    import { mapGetters } from 'vuex';
//    import Cookies from "js-cookie";
//    export default {
//        deger: {
//            ...mapGetters(["girdimi"])
//        },
//        data() {
//            return {
///*                cookie: this.$store.state.giris,*/


//            }
//        },
//        methods: {
//            showAlert() {
//            //mapMutations(['engelle', 'ac']),
//            //this.engelle();
//            this.$store.commit('engelle')
//            Cookies.remove("mail");
//            this.cookie = false;
//            alert(this.cookie);
///*            this.$router.push("/log");*/
//            console.log(this.cookie)
//            window.location.replace("/log")


//            }
//        },
//    };
</script>

<style>
/*    #app {
        font-family: avenir, helvetica, arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }*/

/*    .active {
        background-color: darkblue;
    }*/
</style>
