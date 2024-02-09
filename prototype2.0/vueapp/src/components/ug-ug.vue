<template>
    <div class="container">
        <br />
        <div v-if="basari" class="alert alert-success">basari ile kayit edildi</div>
        <br />
        <div class="form-group">
            <label for="c">isim soyisim</label>
            <input type="text" v-model="isim" id="c" class="form-control" placeholder="isim soyisim" />
        </div>

        <div class="form-group">
            <label for="b">mail</label>
            <input type="text" id="b" v-model="mail" class="form-control" placeholder="mail" />
        </div>

        <div class="form-group">
            <label for="a">sifre</label>
            <input type="text" v-model="sifre" id="a" class="form-control" placeholder="sifre" />
        </div>        
        <div class="form-group">
            <label for="a">telefon</label>
            <input type="text" v-model="telefon" id="a" class="form-control" placeholder="tel" />
        </div>

        <div class="form-group">
            <label for="den">kategoriler</label>
            <div class="col-sm-12">
                <select class="form-select" id="den" v-model="categoryId">
                    <option selected>kategoriler</option>
                    <option v-for="sec in kat" v-bind:value="sec.id">{{sec.aciklama}}</option>
                </select>
                <hr />

                <button v-on:click="add" type="submit" class="btn btn-success"> kullanýcý ekle</button>
            </div>
        </div>


    </div>
</template>
<script>
    import axios from "axios";
    export default {
        data() {
            return {
                kitap: [],
                kat: [],
                isim: "",
                mail: "",
                sifre: "",
                telefon: "",
                categoryId: 0,
                Id: 0,
                basari: false

            };
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/ur").then(res => {
                this.kat = res.data;
                console.log(res);
            });
        },
        methods: {
            add: function () {
                axios.post("https://localhost:7132/api/deneme/e", {
                    isim: this.isim,
                    mail: this.mail,
                    sifre: this.sifre,
                    telefon: this.telefon,
                    kategori: {
                        Id: this.categoryId
                    }
                })
                    .then(res => {
                        this.basari = true;
                        console.log(res);
                    });

            }

        }

    };

</script>
<style>
</style>