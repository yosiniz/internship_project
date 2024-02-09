<template>
    <side-bar2 />
    <div class="flex flex-row" style="width:100%;">
        <Sidebar />
        <div class="wrapper">
            <form action="#">
                <div class="input-box">
                    <input type="text" v-model="isim" placeholder="isim" required>
                </div>
                <div  class="input-box">
                    <input type="text" v-model="mail" placeholder="email" required>
                </div>
                <div class="input-box">
                    <input type="text" v-model="telefon" placeholder="tel" required>
                </div>
                <div class="input-box">
                    <input type="password" v-model="sifre" placeholder="Create password" required>
                </div>
                <div class="input-box">
                    <label for="den">rol</label>
                        <select style="margin-left: 15px; outline: none;" class="form-select" id="den" v-model="categoryId">
                            <option v-for="sec in kat" v-bind:value="sec.id">{{sec.aciklama}}</option>
                        </select>
                </div>

                <div class="input-box button">
                    <input v-on:click="add" type="button" value="kayit ekle">
                </div>
            </form>
        </div>
    </div>
</template>
<script>
    import Sidebar from "@/components/home/sidebar"
    import sideBar2 from "@/components/Account/acheader";
    import axios from "axios";
    import Swal from "sweetalert2";
    export default {
        data() {
            return {
                kitap: [],
                kat: [],
                isim: "",
                mail: "",
                sifre: "",
                telefon:"",
                categoryId: 0,
                Id: 0,
                basari: false,
                user:[],
                

            };
        },
        components: {
            Sidebar,
            sideBar2
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/ur").then(res => {
                this.kat = res.data;
                console.log(res);
            });
            axios.get("https://localhost:7132/api/deneme/kug").then(res => {
                this.user = res.data;
                console.log(res);
            });
        },
        methods: {
            add: function () {
                 axios.post("https://localhost:7132/api/deneme/ue", {
                 isim: this.isim,
                 mail: this.mail,
                 sifre: this.sifre,
                 telefon:this.telefon,
                 rol: {
                 Id: this.categoryId
                 }
                 }),
                     Swal.fire({
                     icon: 'success',
                     title: 'kullanici basari ile eklendi',
                     confirmButtonText: 'Great!',
                     }).then(() => {
                     // Sayfayý yenile
                     window.location.assign("/kg")
                     });
                   }

        }

    };

</script>
<style>
    @import url('https://fonts.googleapis.com/css?family=Poppins:400,500,600,700&display=swap');


    .wrapper {
        margin-top:2%;
        margin-left:25%;
        position: relative;
        max-width: 430px;
        width: 100%;
        background: #fff;
        padding: 34px;
        border-radius: 6px;
        box-shadow: 0 5px 10px rgba(0,0,0,0.2);
    }

        .wrapper h2 {
            position: relative;
            font-size: 22px;
            font-weight: 600;
            color: #333;
        }

            .wrapper h2::before {
                content: '';
                position: absolute;
                left: 0;
                bottom: 0;
                height: 3px;
                width: 28px;
                border-radius: 12px;
                background: #4070f4;
            }

        .wrapper form {
            margin-top: 30px;
        }

            .wrapper form .input-box {
                height: 52px;
                margin: 18px 0;
            }

    form .input-box input {
        height: 100%;
        width: 100%;
        outline: none;
        padding: 0 15px;
        font-size: 17px;
        font-weight: 400;
        color: #333;
        border: 1.5px solid #C7BEBE;
        border-bottom-width: 2.5px;
        border-radius: 6px;
        transition: all 0.3s ease;
    }

    .input-box input:focus,
    .input-box input:valid {
        border-color: #4070f4;
    }

    form .policy {
        display: flex;
        align-items: center;
    }

    form h3 {
        color: #707070;
        font-size: 14px;
        font-weight: 500;
        margin-left: 10px;
    }

    .input-box.button input {
        color: #fff;
        letter-spacing: 1px;
        border: none;
        background: #4070f4;
        cursor: pointer;
    }

        .input-box.button input:hover {
            background: #0e4bf1;
        }

    form .text h3 {
        color: #333;
        width: 100%;
        text-align: center;
    }

        form .text h3 a {
            color: #4070f4;
            text-decoration: none;
        }

            form .text h3 a:hover {
                text-decoration: underline;
            }
</style>