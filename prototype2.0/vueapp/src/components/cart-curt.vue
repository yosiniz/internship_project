<template>
    <h1>kitap</h1>
    <div class="container">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">kitap ID</th>
                    <th scope="col">kitap ismi</th>
                    <th scope="col">kitap fiyatı</th>
                    <th scope="col">kitap stok adedi</th>
                    <th scope="col">kitap kategori</th>
                    <th scope="col">islemler</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="kit in kitap">
                    <td scope="row">{{kit.id}}</td>
                    <td>{{kit.kitapAdi}}</td>
                    <td>{{kit.fiyat}}</td>
                    <td>{{kit.stok}}</td>
                    <td>{{kit.kategori.kategoriAdi}}</td>
                    <td>
                        <i class="fa-solid fa-trash"></i>
                        &nbsp;
                        <i class="fa-solid fa-pen-to-square"></i>
                        &nbsp;
                        <i class="fa-solid fa-check"></i>

                    </td>
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
                kitap: []
            };
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme").then(res => {
                this.kitap = res.data;
                console.log(res);
            });
        },
    };


</script>
<style>
</style>
