<template>
    <div class="container">
        <h1>login</h1>
        <div class="form-group">
            <label for="c">mail</label>
            <input type="text" v-model="maile" id="c" class="form-control" placeholder="email" />
        </div>
        <div class="form-group">
            <label for="c">sifre</label>
            <input type="text" v-model="sifree" id="c" class="form-control" placeholder="sifre" />
        </div>
        <br />
        <button v-on:click="gir" class="btn btn-danger">login</button>

    </div>

</template>
<script>
    import axios from "axios";
    export default {
        data() {
            return {
                mail: "",
                sif: "",
                veri: []

            }
        },
        methods: {
            gir: function () {
                axios.post("https://localhost:7132/api/deneme/l", {
                    mail: this.maile,
                    sifre: this.sifree
                })
                 axios.get("https://localhost:7132/api/deneme/lk").then(res =>
                        this.mailler = res.data;
                for (kit in mailler) {
                    if (kit.mail==this.maile&&kit.sifre==this.sifree) {
                         this.$router.push('/tum');
                    }
                }
                   

            }
        }


    }
</script>
<style>
</style>