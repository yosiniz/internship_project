<template>
    <h1>kitap</h1>
    <div class="container">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">kullanici ID</th>
                    <th scope="col">kullanici ismi</th>
                    <th scope="col">kullanici mail</th>
                    <th scope="col">kullanici sifre</th>
                    <th scope="col">kullanici telefon no</th>
                    <th scope="col">kullanici rol</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="kit in kitap"  :key="kit.id">
                    <td scope="row">{{kit.id}}</td>
                    <td>{{kit.isim}}</td>
                    <td>{{kit.mail}}</td>
                    <td>{{kit.sifre}}</td>
                    <td>{{kit.telefon}}</td>
                    <td>{{kit.rol.aciklama}}</td>
                    <td>
                        <button  v-on:click="silme(kit.id)" class="btn ative"><i class="fa-solid fa-trash"></i></button>
                        <!--&nbsp;-->
                        <button class="btn ative"><i class="fa-solid fa-pen-to-square"></i></button>
                        <!--&nbsp;-->
                        <button class="btn ative"><i class="fa-solid fa-check"></i></button>
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
                Id:0
            };
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/kug").then(res => {
                this.kitap = res.data;
                console.log(res);
            });

        },
     methods: {
            silme: function (id) {
                axios.post("https://localhost:7132/api/deneme/dk", {
                    Id: id
                }),
                    location.reload();
                console.log(id)
            }
        }
    };


</script>
<style>
    .ative:hover {
        background-color: lightgrey;
    }
</style>
