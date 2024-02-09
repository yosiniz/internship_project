<template>


    <!--<div class="login_register_container">
        <div class="container text-2xl text-center mb-3">
            <div class="form-group">
                <label for="c">mail</label>
                <input type="text" v-model="maile" id="c" class="form-control" placeholder="email" />
            </div>
            <div class="form-group">
                <label for="c">sifre</label>
                <input type="password" v-model="sifree" id="c" class="form-control" placeholder="sifre" />
            </div>
            <br />
            <button v-on:click="gir" class="btn btn-danger">login</button>

        </div>
    </div>-->



    <div >
        <div style="margin-left:33%; margin-top:40px;">
            <img src="./gm-logo-black-new.png" style="height:60px; width:500px; " />
        </div>
        <div style="margin-top:50px;" class="asd">
            <h3 style="color: black; font-family: cursive;">giris yap</h3>

            <label style="color: black; font-family: cursive;" for="mail">mail</label>
            <input style="color:black;" placeholder="mail" type="text" v-model="maile" id="mail">

            <label style="color: black; font-family: cursive;" for="sifre">sifre</label>
            <input style="color:black;" placeholder="sifre" type="password" v-model="sifree" id="sifre">

            <button style="color: black; font-family: cursive;" v-on:click="gir">Log In</button>
        </div>
    </div>


</template>
<script>
    import { mapGetters, mapMutations } from 'vuex';
    import VueCookies from 'vue-cookies'
    //import { mapState, mapMutations } from 'vuex';
    import axios from "axios"
    import Swal from "sweetalert2";

    export default {
        deger: {
            ...mapGetters(["girdimi"])
        },
        data() {
            return {
                userData: {
                    mail: "",
                    sifree: ""
                },
                deleteUserText: 'Delete Cookie',
                deleteUserState: '',
                mail: "",
                sif: "",
                veri: [],
                token: "",
                tokenParts: [],
                encodedPayload: "",
                decodedPayload: "",
                payloadData: "",
                rol: "",
                emaill: null
            }
        },
        methods: {
            ...mapMutations(["ac"]),
            ...mapMutations(["rolal"]),
            ...mapMutations(["mailal"]),
            gir: function () {
                if (this.maile == null || this.sifree == null) {
                    Swal.fire({
                        icon: 'error',
                        title: 'lutfen mail ve sifreyi eksiksiz doldurun',
                        confirmButtonText: 'tamam!',
                    })
                }

                else if (this.maile != null && this.sifree != null) {
                    axios.post("https://localhost:7132/api/deneme/l", {
                        mail: this.maile,
                        sifre: this.sifree

                    }).then(response => {
                        this.ac();
                        this.token = response.data.token;
                        this.tokenParts = this.token.split(".");
                        this.encodedPayload = this.tokenParts[1];
                        this.decodedPayload = atob(this.encodedPayload);
                        this.payloadData = JSON.parse(this.decodedPayload);
                        this.emaill=this.payloadData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
                        //console.log(this.payloadData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
                        this.rol = this.payloadData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                        this.rolal(this.rol)
                        this.mailal(this.emaill)
                        //window.location.replace("/")
                        /*                        this.$router.push("/")*/
                        console.log(this.token)
                        window.location.assign("/")





                        var user = { mail: `${this.maile}`, session: `${this.rol}` };
                        this.$cookies.set('user', user);
                        // print user name
                        console.log(this.$cookies.get('user').name)


                    })
                        .catch(e => {
                            /*console.log(e.response.data.error)*/
                            if (e.response && e.response.status == 400) {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'hatali giris bilgilreri',
                                    confirmButtonText: 'tamam!',
                                }).then(() => {
                                    // Sayfayı yenile
                                    //window.location.assign("/log")

                                });
                            }
                        })

                }

            }
        }
    }
</script>
<style>
    .background {
        width: 430px;
        height: 520px;
        position: absolute;
        transform: translate(-50%,-50%);
        left: 50%;
        top: 50%;
    }

        .background .shape {
            height: 200px;
            width: 200px;
            position: absolute;
            border-radius: 50%;
        }

    .shape:first-child {
        background: linear-gradient( #1845ad, #23a2f6 );
        left: -80px;
        top: -80px;
    }

    .shape:last-child {
        background: linear-gradient( to right, #ff512f, #f09819 );
        right: -30px;
        bottom: -80px;
    }

    .asd {
        height: 520px;
        width: 400px;
        background-color: rgba(255,255,255,0.13);
        position: absolute;
        transform: translate(-50%,-50%);
        top: 50%;
        left: 50%;
        border-radius: 10px;
        backdrop-filter: blur(10px);
        border: 2px solid rgba(255,255,255,0.1);
        box-shadow: 0 0 40px rgba(8,7,16,0.6);
        padding: 50px 35px;
    }

        .asd * {
            font-family: 'Poppins',sans-serif;
            color: #ffffff;
            letter-spacing: 0.5px;
            outline: none;
            border: none;
        }

        .asd h3 {
            font-size: 32px;
            font-weight: 500;
            line-height: 42px;
            text-align: center;
        }

    label {
        display: block;
        margin-top: 30px;
        font-size: 16px;
        font-weight: 500;
    }

    input {
        display: block;
        height: 50px;
        width: 100%;
        background-color: rgba(255,255,255,0.07);
        border-radius: 3px;
        padding: 0 10px;
        margin-top: 8px;
        font-size: 14px;
        font-weight: 300;
    }

    ::placeholder {
        color: #e5e5e5;
    }

        button {
        margin-top: 50px;
        width: 100%;
        background-color: #ffffff;
        color: #080710;
        padding: 15px 0;
        font-size: 18px;
        font-weight: 600;
        border-radius: 5px;
        cursor: pointer;
    }
</style>