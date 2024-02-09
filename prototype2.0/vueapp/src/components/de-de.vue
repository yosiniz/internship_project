<template>
    <div class="container">
        <div class="form-group row">
            <div class="col-sm-12">
                <select class="form-select" id="den" v-model="categoryId">
                    <option selected>kategoriler</option>
                    <option v-for="sec in secenek" v-bind:value="sec.id">{{sec.kategoriAdi}}</option>
                </select>
            </div>
            <button v-on:click="getir" class="btn btn-primary"><i class="fa-solid fa-magnifying-glass"></i></button>
        </div>
        <table v-if="!goster" class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">kitap ID</th>
                    <th scope="col">kitap ismi</th>
                    <th scope="col">kitap fiyati</th>
                    <th scope="col">kitap stok adedi</th>
                    <th scope="col">kitap kategori</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="kit in kitap">
                    <td scope="row">{{kit.id}}</td>
                    <td>{{kit.kitapAdi}}</td>
                    <td>{{kit.fiyat}}</td>
                    <td>{{kit.stok}}</td>
                    <td>{{kit.kategori.kategoriAdi}}</td>
                </tr>
            </tbody>
        </table>


        <table v-if="goster" class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">kitap ID</th>
                    <th scope="col">kitap ismi</th>
                    <th scope="col">kitap fiyati</th>
                    <th scope="col">kitap stok adedi</th>
                    <th scope="col">kitap kategori</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="fi in filt">
                    <td scope="row">{{fi.id}}</td>
                    <td>{{fi.kitapAdi}}</td>
                    <td>{{fi.fiyat}}</td>
                    <td>{{fi.stok}}</td>
                    <td>{{fi.kategori.kategoriAdi}}</td>
                </tr>

            </tbody>
        </table>

    </div>

</template>
<script>

    import axios from "axios";
    export default {
        data() {
            return {
                kitap: [],
                secenek: [],
                goster: false,
                filt: [],
                categoryId:0
            };
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/k").then(res => {
                this.kitap = res.data;

            });
            axios.get("https://localhost:7287/api/deneme/h").then(res => {
                this.secenek = res.data;
                console.log(this.secenek.id)
            });


        },
        methods: {
            getir: function () {
                console.log(this.categoryId)
                this.filt = this.kitap.filter(i => i.kategori.id == this.categoryId)
                console.log(this.filt)
                this.goster=true

            }
        }


    };


</script>
<style>
</style>
