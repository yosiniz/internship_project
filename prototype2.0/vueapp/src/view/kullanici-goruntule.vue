<template>
    <side-bar2 />
    <div class="flex flex-row" style="width:100%;">
        <Sidebar />
        <div class="butun" style="width:10%;">
            <div class="ilk" style="border-radius: 10px; margin-left: 10%; margin-top: 100px; display: inline-block; float: left; padding: 1%;">
                <label>isim:</label> 
                <input style="outline: none; font-family: 'Times New Roman', Times, serif;" type="text" placeholder="filtrele" class="arab " v-model="AramaDegeri" />
            </div>
            <div class="iki" style="border-radius: 10px; margin-left: 10%; display: inline-block; float: left; margin-top: 5%; padding: 1%; ">
                <label>rol:</label> 
                <input style="outline: none; margin-left: 0px; font-family: 'Times New Roman', Times, serif;" type="text" placeholder="filtrele" class="arab"  v-model="AramaDegeri2" />
            </div>
        </div>

        <div style="margin-left:100px; margin-top:6.5%; margin-right:5%;">
            <div class="container">
                <table class="table table-striped">
                    <thead>
                        <tr style=" background-color: #009879; border-radius: 12px; height: 55px;">
                            <th style="padding-left: 35px;" scope="col">kullanici ID</th>
                            <th style="padding-left: 35px;" scope="col">kullanici ismi</th>
                            <th style="padding-left: 35px;" scope="col">kullanici mail</th>
                            <th style="padding-left: 35px;" scope="col">kullanici telefon no</th>
                            <th style="padding-left: 35px;" scope="col">kullanici rol</th>
                            <th v-if="rol !=`okur`" style="padding-left: 60px; padding-right: 35px;" scope="col">islemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr style=" border-bottom: 1px solid #009879;" v-for="kit in kitaps" :key="kit.id">
                            <td style="padding-top: 15px; padding-bottom:15px; padding-left: 50px;" scope="row">{{kit.id}}</td>
                            <td style="padding-top: 15px; padding-bottom: 15px; padding-left: 50px; ">{{kit.isim}}</td>
                            <td style="padding-top: 15px; padding-bottom: 15px; padding-left: 50px; ">{{kit.mail}}</td>
                            <td style="padding-top: 15px; padding-bottom: 15px; padding-left: 90px; ">05{{kit.telefon}}</td>
                            <td style="padding-top: 15px; padding-bottom: 15px; padding-left: 50px; ">{{kit.rol.aciklama}}</td>
                            <td v-if="rol !=`okur`" style="padding-top: 15px; padding-bottom: 15px; padding-left: 60px; ">
                                <button v-if="rol !=`okur`" v-on:click="silme(kit.id)" style="margin-left:8px;" class="btn ative"><i class="fa-solid fa-trash"></i></button>
                                <!--<button v-if="rol !=`okur`" style="padding-left: 10px; margin-left: 15px;" class="btn ative"><i class="fa-solid fa-pen-to-square"></i></button>-->
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>
            <div v-if="kitaps==0" style="margin-left:38%; margin-top:10%;">
                <h1>Aradiginiz kisi bulunmamakta...</h1>
            </div>
        </div>


    </div>
</template>
<script>
    import axios from "axios";
    import Sidebar from "@/components/home/sidebar"
    import sideBar2 from "@/components/Account/acheader";
    import Swal from "sweetalert2";
    import { mapGetters } from 'vuex';
    export default {
        computed: {
            ...mapGetters(["rolne"])
        },
        data() {
            return {
                user: [],
                AramaDegeri: "",
                sonuc: [],
                AramaDegeri2: "",
                rol: this.$store.state.rol,
            }
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/kug").then(res => {
                this.user = res.data;
                console.log(res);
            });

        },
        methods: {
            silme: function (id) {
                axios.post("https://localhost:7132/api/deneme/dk", {
                    Id: id
                }),

                    Swal.fire({
                        icon: 'success',
                        title: 'kullanici basari ile silindi',
                        confirmButtonText: 'Great!',
                    }).then(() => {
                        // Sayfayý yenile
                        window.location.assign("/kg")
                    });

            },
        },
        components: {
            Sidebar,
            sideBar2
        },
        computed: {
            kitaps() {
                if (this.AramaDegeri != "" && this.AramaDegeri2 == "") {
                    return this.user.filter((user) => user.isim.toLowerCase().includes(this.AramaDegeri.trim().toLowerCase()))
                }
                else if (this.AramaDegeri2 == "" && this.AramaDegeri == "") {
                    return this.user
                }
                else if (this.aramaDegeri2 != "" && this.AramaDegeri == "") {
                    return this.user.filter((user) => user.rol.aciklama.toLowerCase().includes(this.AramaDegeri2.trim().toLowerCase()))
                }
                else if (this.aramaDegeri2 != "" && this.AramaDegeri != "") {
                    //return this.sonuc.filter((user) => user.rol.aciklama.toLowerCase().include(this.AramaDegeri2.trim().toLoweCase()) && user.isim.toLowerCase().include(this.AramaDegeri.trim().toLowerCase()))
                    return this.user.filter((user) => 
                        user.isim.toLowerCase().includes(this.AramaDegeri.trim().toLowerCase())&&
                        user.rol.aciklama.toLowerCase().includes(this.AramaDegeri2.trim().toLowerCase()))                       
                    

                }
               
            },
            //users() {
            //    if (this.AramaDegeri != "") {
            //        this.sonuc = this.user.filter((user) => user.isim.toLowerCase().includes(this.AramaDegeri.trim().toLowerCase()))
            //        return this.sonuc
            //    }
            //    else if (this.AramaDegeri2=="") {
            //        this.sonuc = this.user
            //        return this.sonuc
            //    }

            //},
            //userss() {
            //    if (this.AramaDegeri2 != "") {
            //        this.sonuc = this.user.filter((user) => user.rol.toLowerCase().includes(this.AramaDegeri2.trim().toLowerCase()))
            //        return this.sonuc
            //    }
            //    else if (this.AramaDegeri == "") {
            //        this.sonuc = this.user
            //        return this.sonuc
            //    }

            //},
        },

    }
</script>
<style>
    input-without-outline:focus {
        outline: none;
    }

</style>