<template>
    <side-bar2 />
    <div class="flex flex-row" style="width:100%;">
        <Sidebar />
        <div class="butun" style="width:20%; margin-left:150px;">
            <div class="ilk" style="border-radius: 10px; margin-left: 10%; margin-top: 100px; display: inline-block; float: left; padding: 1%;">
                <h1 style="font-family:'Times New Roman', Times, serif; font-size:x-large;" class="h1">kategori ekle</h1>
                <div style="margin-top:20px;" class="form-group">
                    <label style="font-family:Calibri; font-size:large;" for="b">kategori adi</label>
                    <input type="text" id="b" v-model="kategoriAdi" class="input" />
                    <button  v-if="rol !=`okur`" style="margin-top:15px; background-color:lightgreen;" v-on:click="add" class="bookmark-btn"> ekle </button>
                </div>
            </div>
        </div>

        <div style=" margin-top:6.5%; margin-right:5%; margin-left:150px;">
            <div class="container">
                <table class="table table-striped" style="height:100%;">
                    <thead>
                        <tr style=" background-color: #80ced6; border-radius: 12px; height: 25px;">
                            <th style=" text-align:center;" scope="col">kategori adi</th>
                            <th style=" padding-left:50px; padding-right:20px; text-align:center;" scope="col">islemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr style=" border-bottom: 1px solid #009879;" v-for="kit in kag" :key="kit.id">
                            <td style="padding-top: 5px; padding-bottom:5px; padding-left: 20px; ">{{kit.kategoriAdi}}</td>
                            <td style="text-align: center; padding-top: 15px; padding-bottom: 15px; padding-left: 50px; padding-right: 20px; ">
                                <button  @click="isopen=true" v-on:click="cek(kit.id) , id=kit.id " style="padding-left:20px;" class="btn ative"><i class="fa-solid fa-pen-to-square"></i></button>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>
        </div>
    </div>

    <transition name="fade" appear>
        <div class="modall-overlay" v-if="isopen"></div>
    </transition>
    <v-menu scroll-x-transition>

    </v-menu>
    <transition name="slide" appear>
        <div style="text-align:center;" v-for="kit2 in kitap2" class="modall" v-if="isopen">
            <table style="text-align:center; margin-top:3%; margin-right:auto; margin-left:auto;" class="styled-table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>kategori adi</th>
                        <th scope="col">islemler</th>

                    </tr>
                </thead>
                <tbody>
                    <tr :key="kit2.id">
                        <td scope="row">{{kit2.id}}</td>
                        <td>{{kit2.kategoriAdi}}</td>
                        <td>
                            <button v-on:click="del(kit2.kategoriAdi)"  v-if="rol==`admin`" class="btn ative"><i class="fa-solid fa-trash"></i></button>
                            &nbsp;
                            <!--<router-link :to="{name:`edit`}"> <button v-on:click="" class="btn ative"><i class="fa-solid fa-pen-to-square"></i></button></router-link>-->
                            &nbsp;
                            <button @click="isopen=false" class="btn ative"><i class="fa-solid fa-check"></i></button>
                            <!--<button v-on:click="silme(kit2.id)" class="btn ative"><i class="fa-solid fa-trash"></i></button>-->
                           
                        </td>
                    </tr>
                </tbody>
            </table>

            <input type="text" v-model="{{kit2.id}}"  class="form-control" :placeholder="kit2.id" readonly/>
            <input type="text" v-model="katadi" class="form-control" :placeholder="kit2.kategoriAdi"  />
            <br />
            <button v-if="rol !=`okur`" v-on:click="edt" style="background-color: lightgreen; width:100px; height:30px; border-radius:5px;">degistir</button>
            <button style=" margin-top: 15px; margin-left:20px; width: 100px; height: 30px; border-radius: 5px; background-color: lightcoral;"  @click="isopen=false">cikis</button>
        </div>
    </transition>

</template>
<script>
    import Sidebar from "@/components/home/sidebar";
    import sideBar2 from "@/components/Account/acheader";
    import axios from "axios";
    import Swal from "sweetalert2";
    import { mapGetters } from 'vuex';
    export default {
        data() {
            return {
                kag: [],
                isopen: false,
                kitap2: [],
                id: null,
                rol: this.$store.state.rol,

            };

        },
        computed: {
            ...mapGetters(["rolne"])
        },

        components: {
            Sidebar,
            sideBar2
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/ktg").then(res => {
                this.kag = res.data;
                console.log("kategori",this.kag);
            });
        },
        methods: {
            add: function () {
                axios.post("https://localhost:7132/api/deneme/ktgek", {
                    kategoriAdi: this.kategoriAdi
                }),
                    Swal.fire({
                        icon: 'success',
                        title: 'kategori basari ile eklendi',
                        confirmButtonText: 'tamam!',
                    }).then(() => {
                        // Sayfayý yenile
                        window.location.assign("/ktg")
                    });
            },

             cek: function (id) {
                    axios.get(`https://localhost:7132/api/deneme/ktgedt/${id}`).then(res => {
                    this.kitap2 = res.data;

                    console.log(this.kitap2)
                    });
                   },
            
            edt: function () {
                axios.post("https://localhost:7132/api/deneme/edtktg", {
                    Id:this.id,
                    kategoriAdi: this.katadi
                }),
                    Swal.fire({
                        icon: 'success',
                        title: 'kategori basari ile güncellendi',
                        confirmButtonText: 'tamam!',
                    }).then(() => {
                        // Sayfayý yenile
                        window.location.assign("/ktg")
                    });

            },
            del: function (katadi) {
                axios.post("https://localhost:7132/api/deneme/dltktg", {
                    Id: this.id,
                    kategoriAdi: katadi
                }),
                    Swal.fire({
                        icon: 'warning',
                        title: 'secilen kategori basari ile silindi baglantili kitaplari kontrol et!',
                        confirmButtonText: 'tamam!',
                    }).then(() => {
                        // Sayfayý yenile
                        window.location.assign("/ktg")
                    });

            },
            getir: function (ad) {
                axios.get(`https://localhost:7132/api/deneme/kg/${ad}`).then(res => {
                    this.kagor = res.data;

                    console.log(this.kagor)
                });
            }
        }
    }
</script>
<style>

    .styled-table tbody tr.active-row {
        font-weight: bold;
        color: #009879;
    }

    .styled-table tbody tr {
        border-bottom: 1px solid #dddddd;
    }

        .styled-table tbody tr:nth-of-type(even) {
            background-color: #f3f3f3;
        }

        .styled-table tbody tr:last-of-type {
            border-bottom: 2px solid #009879;
        }

    .styled-table th,
    .styled-table td {
        padding: 12px 15px;
    }

    .styled-table thead tr {
        background-color: #009879;
        color: #ffffff;
        text-align: left;
    }

    .styled-table {
        border-collapse: collapse;
        margin: 25px 0;
        font-size: 0.9em;
        font-family: sans-serif;
        min-width: 400px;
        box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
    }

    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    body {
        font-family: "montserrat",sans-serif;
    }
    /*    #app{
        position:relative;
        display:flex;
        justify-content:center;
        align-items:center;
        width:100vw;
        min-height:100vh;
        overflow-x:hidden;
    }*/

    .modall {
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%,-50%);
        z-index: 99;
        width: 500px;
        max-width: 500px;
        background-color: #fff;
        border-radius: 16px;
        padding: 25px;
    }

    .den {
        overflow-wrap: break-word;
        color: #222;
        font-size: 32px;
        font-weight: 900;
        margin-bottom: 15px;
    }

    .den2 {
        overflow-wrap: break-word;
        color: #666;
        font-size: 18px;
        font-weight: 400;
        margin-bottom: 15px;
    }

    .button {
        appearance: none;
        outline: none;
        border: none;
        background: none;
        cursor: pointer;
        display: inline-block;
        padding: 15px 25px;
        border-radius: 8px;
    }

    .modall-overlay {
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        z-index: 98;
        background-color: rgba(0,0,0,0.3);
    }

    .fade-enter-active,
    .fade-leave-active {
        transition: opacity 0.5s;
    }

    .fade-enter,
    .fade-leave-to {
        opacity: 0;
    }

    .slide-enter-active,
    .slide-leave-active {
        transition: transform .5s;
    }

    .slide-enter,
    .slide-leave-to {
        transform: translateY(-50%) translateX(100vw);
    }
</style>