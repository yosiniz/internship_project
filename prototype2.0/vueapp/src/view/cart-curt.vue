<template>
    <h1>kitap</h1>
    <div class="container">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">kitap ID</th>
                    <th scope="col">kitap ismi</th>
                    <th scope="col">kitap fiyatý</th>
                    <th scope="col">kitap stok adedi</th>
                    <th scope="col">kitap kategori</th>
                    <th scope="col">islemler</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="kit in kitap" :key="kit.id">
                    <td scope="row" >{{kit.id}}</td>
                    <td>{{kit.kitapAdi}}</td>
                    <td>{{kit.fiyat}}</td>
                    <td>{{kit.stok}}</td>
                    <td>{{kit.kategori.kategoriAdi}}</td>
                    <td>
                        <button  v-on:click="silme(kit.id)" class="btn ative"><i class="fa-solid fa-trash"></i></button>
                        <!--&nbsp;-->
                        <button  class="btn ative"><i class="fa-solid fa-pen-to-square"></i></button>
                        <!--&nbsp;-->
                        <button  class="btn ative"><i class="fa-solid fa-check"></i></button>
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
                kitap: [],
                sutun:0
            };
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme").then(res => {
                this.kitap = res.data;
                console.log(res);
            });
        },
        methods: {
            silme: function (id) {
                axios.post("https://localhost:7132/api/deneme/d", {
                    Id: id
                }),
                    location.reload();
                    console.log(id)
            }
        }
    };


</script>
<style>
    .ative:hover{
        background-color:black;
    }
</style>
