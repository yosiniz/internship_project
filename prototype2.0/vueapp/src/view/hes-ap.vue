<template>
    <side-bar2 />
        <div  class="flex flex-row" style="width:100%;">
            <side-bar />
            <div class="butun" style="width:50%; float:right; margin-left:150px; display:inline-block; margin-top:50px;">
                <div style="margin-bottom: 50px; margin-left: 400px; font-family: cursive;">
                    <h1>bilgiler</h1>
                </div>
                <form style="margin-left:150px;"   v-for="kit in kitap2">
                    <label style="font-family:'MS Reference Sans Serif';">isim</label>
                    <input class="a" type="text" style="margin-left:15px; background-color: #fafafa;" readonly :placeholder="kit.isim" />

                    <label style="font-family:'MS Reference Sans Serif';">mail</label>
                    <input class="a" type="text" style="margin-left:15px; background-color: #fafafa;" readonly :placeholder="kit.mail" />

                    <label style="font-family:'MS Reference Sans Serif';">rol</label>
                    <input class="a" type="text" style="margin-left:15px; background-color: #fafafa;" readonly :placeholder="kit.rol.aciklama" />

                    <label style="font-family:'MS Reference Sans Serif';">telefon</label>
                    <input class="a" type="text" style="margin-left:15px; background-color: #fafafa;" readonly :placeholder="kit.telefon" />
                    <input v-if="rol=='admin'" style="margin-left:15px;" type="submit" value="Submit">
                </form>



            </div>
        </div>
</template>
<script>
    import { mapGetters } from 'vuex';
    import axios from "axios";
    import sideBar from "@/components/Account/sideBar";
    import sideBar2 from "@/components/Account/acheader";
    export default {
        computed: {
            ...mapGetters(["mailne"]),
            ...mapGetters(["rolne"])
        },
        data() {
            return {
                kitap2:[],
                mail: this.$store.state.mail,
                rol:this.$store.state.rol,
            }
        },
        created: function () {
            axios.get(`https://localhost:7132/api/deneme/h/${this.mail}`).then(res => {
                this.kitap2 = res.data;
                console.log("bilgi",this.kitap2)
            });


        },
        components: {
            sideBar,
            sideBar2
        }
    }
</script>
<style>
    input[class=a], select {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    input[type=submit] {
        width: 100%;
        background-color: #4CAF50;
        color: white;
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

        input[type=submit]:hover {
            background-color: #45a049;
        }

</style>