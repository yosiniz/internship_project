<template>
    <div style="width: 100%; margin-top: 25px;">
        <div style="display:inline; width:250px; height:25px; margin-left:27%; ">
            <input type="text" placeholder="isime gore filtrele" class="arab " v-model="AramaDegeri" />
            <input style="margin-left:105px;" type="text" placeholder="kategoriye gore filtrele" class="arab " v-model="AramaDegeri2" />
        </div>
        <div style="width: 100%;  margin-top: 25px;" class="grid grid-cols-6">
            <div style="border-left: 1px solid #000; border-bottom: 1px solid #000; border-radius: 10px; height: 150px; padding-top: 25px; margin: 10%; " class="p-1 bg-gray-100" v-for="kit in kitaps" :key="kit.id">

                <a href="#" @click="isopen=true" :key="kit.id" v-on:click="cek(kit.id)" class="hover:text-black font-bold text-l mb-6 text-gray-600 text-center"><p style="text-align:center;">{{kit.cihazAdi}}</p></a>
                <div class="flex items-center justify-center mt-2 gap-x-1">
                    <!--<button class="like-btn group">
                    <div class="fill-current group-hover:text-white" height="24" viewBox="0 0 24 24" width="24">
                        <i style="font-size:larger;" class="fa-solid fa-star"></i>
                    </div>
                </button>-->
                    <!--<button class="bookmark-btn group ">
                    <div class="fill-current group-hover:text-white" viewBox="0 0 24 24" width="24" height="24">
                        <i v-if="kit.stok>0" style="font-size:larger;" class="fa-solid fa-cart-shopping"></i>
                        <i v-if="kit.stok<1" class="fa-solid fa-xmark fa-xl"></i>
                    </div>
                </button>-->
                    <div class="relative group">
                        <button class="details-btn !-z-[1] group">
                            <div class="fill-current group-hover:text-gray-700" height="24" viewBox="0 0 24 24" width="24">
                                <i style="font-size:larger;" class="fa-solid fa-comment"></i>
                            </div>
                            <p class="details-container">{{kit.ozellik}}</p>
                        </button>
                    </div>
                </div>
                <div class="text-xs text-gray-400 mt-2 flex justify-between">
                    <a href="#" class="hover:text-black"> fiyati: {{kit.fiyat}}</a>
                    <span>{{kit.kategori.kategoriAdi}}</span>
                </div>
            </div>
        </div>
        <div v-if="kitaps==0" style="margin-left:38%; margin-top:10%;">
            <h1>Aradiginiz urun bulunmamakta...</h1>
        </div>
    </div>






    <transition name="fade" appear>
        <div class="modal-overlay" v-if="isopen"></div>
    </transition>
    <v-menu scroll-x-transition>

    </v-menu>
    <transition name="slide" appear>
        <div style="text-align:center;" v-for="kit2 in kitap2" class="modal" v-if="isopen">
          <div style="margin-left:45%;" class="slayt"><img style="width:80px; height:180px;" :src="kit2.resim"/></div>
            <table style="text-align:center; margin-top:3%; margin-right:auto; margin-left:auto;" class="styled-table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>cihaz adi</th>
                        <th>ozellikler</th>
                        <th>durum</th>
                        <th>serino</th>
                        <th>fiyati</th>
                        <th>stok adedi</th>
                        <th>kategori</th>
                        <th scope="col">islemler</th>

                    </tr>
                </thead>
                <tbody>
                    <tr :key="kit2.id">
                        <td scope="row">{{kit2.id}}</td>
                        <td>{{kit2.cihazAdi}}</td>
                        <td>{{kit2.ozellik}}</td>
                        <td>{{kit2.durum}}</td>
                        <td>{{kit2.serino}}</td>
                        <td>{{kit2.fiyat}} TL</td>
                        <td>{{kit2.stok}}</td>
                        <td>{{kit2.kategori.kategoriAdi}}</td>
                        <td>
                            <button v-on:click="silme(kit2.id)" class="btn ative"><i class="fa-solid fa-trash"></i></button>
                            &nbsp;
                            <router-link :to="{name:`edit`}"> <button v-on:click="edit(kit2.id)" class="btn ative"><i class="fa-solid fa-pen-to-square"></i></button></router-link>                           
                            &nbsp;
                            <button @click="isopen=false" class="btn ative"><i class="fa-solid fa-check"></i></button>
                        </td>
                    </tr> 
                </tbody>
            </table>
            <button class="button" @click="isopen=false">cikis</button>
        </div>
    </transition>







</template>
<script>
    import {mapMutations} from 'vuex';
    import Swal from "sweetalert2";
    import axios from "axios";
    export default {
        data() {
            return {
                slide: 0,
                sliding: null,
                AramaDegeri: "",
                AramaDegeri2: "",
                kitap: [],
                kitap2: [],
                sutun: 0,
                isopen: false,
                resim: [],
                url:""
            };
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme").then(res => {
                this.kitap = res.data;
                console.log(res);
            });
            axios.get("https://localhost:7132/api/deneme/h").then(res => {
                this.kat = res.data

            });


        },

        methods: {
            ...mapMutations(["iddegis"]),
            silme: function (id) {
                axios.post("https://localhost:7132/api/deneme/d", {
                    Id: id
                }),

                    Swal.fire({
                        icon: 'success',
                        title: 'cihaz basari ile silindi',
                        confirmButtonText: 'tamam!',
                    }).then(() => {
                        // Sayfayý yenile
                        window.location.assign("/")
                    });

            },
            edit: function (id) {
                this.iddegis(id)
            },

            cek: function (id) {
                axios.get(`https://localhost:7132/api/deneme/t/${id}`).then(res => {
                    this.kitap2 = res.data;
                    console.log(this.kitap2)
                });
            }
        },
        computed: {
            //kitaps() {
            //    if (this.AramaDegeri != "") {
            //        return this.kitap.filter((kitap) => kitap.cihazAdi.toLowerCase().includes(this.AramaDegeri.trim().toLowerCase()))
            //    }
            //    return this.kitap
            //},
            kitaps() {
                if (this.AramaDegeri != "" && this.AramaDegeri2 == "") {
                    return this.kitap.filter((kitap) => kitap.cihazAdi.toLowerCase().includes(this.AramaDegeri.trim().toLowerCase()))
                }
                else if (this.AramaDegeri2 == "" && this.AramaDegeri == "") {
                    return this.kitap
                }
                else if (this.aramaDegeri2 != "" && this.AramaDegeri == "") {
                    return this.kitap.filter((kitap) => kitap.kategori.kategoriAdi.toLowerCase().includes(this.AramaDegeri2.trim().toLowerCase()))
                }
                else if (this.aramaDegeri2 != "" && this.AramaDegeri != "") {
                    //return this.sonuc.filter((user) => user.rol.aciklama.toLowerCase().include(this.AramaDegeri2.trim().toLoweCase()) && user.isim.toLowerCase().include(this.AramaDegeri.trim().toLowerCase()))
                    return this.kitap.filter((kitap) =>
                        kitap.cihazAdi.toLowerCase().includes(this.AramaDegeri.trim().toLowerCase()) &&
                        kitap.kategori.kategoriAdi.toLowerCase().includes(this.AramaDegeri2.trim().toLowerCase()))


                }
            },
            currentImage() {
                return require('@/assets/' + this.images[this.currentImageIndex]);
            }
           
        }
    };

</script>
<style>


/*vdsvdv*/
    .arab {
        border-radius: 5px;
        background-color: rgba(243, 244, 246, var(--tw-bg-opacity));
    }

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

    .modal {
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%,-50%);
        z-index: 99;
        width:1000px;
        max-width: 1000px;
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

    .modal-overlay {
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