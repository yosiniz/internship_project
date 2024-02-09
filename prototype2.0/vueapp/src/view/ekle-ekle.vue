<template>
    <div class="container">
        <br />
        <div v-if="basari" class="alert alert-success">basari ile kayit edildi</div>
        <div class="form-group">
            <label for="c">kitap adi</label>
            <input type="text" v-model="kitapAdi" id="c" class="form-control" placeholder="kitap adi" />
        </div>

        <div class="form-group">
            <label for="b">fiyat</label>
            <input type="text" id="b" v-model="fiyat" class="form-control" placeholder="kitap fiyati" />
        </div>

        <div class="form-group">
            <label for="a">stok</label>
            <input type="text" v-model="stok" id="a" class="form-control" placeholder="kitap stok" />
        </div>

        <div class="form-group">
            <label for="den">kategoriler</label>
            <div class="col-sm-12">
                <select class="form-select" id="den" v-model="categoryId">
                    <option selected>kategoriler</option>
                    <option v-for="sec in kat" v-bind:value="sec.id">{{sec.kategoriAdi}}</option>
                </select>
                <hr />

                <button v-on:click="add" type="submit" class="btn btn-success"> kitabi ekle</button>
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
                kitapAdi: "",
                fiyat: 0,
                stok: 0,
                categoryId: 0,
                Id: 0,
                basari: false

            };
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/h").then(res => {
                this.kat = res.data;
                console.log("kategori",res);
            });
        },
        methods: {
            add: function () {
                axios.post("https://localhost:7132/api/deneme/e", {
                    kitapAdi: this.kitapAdi,
                    fiyat: this.fiyat,
                    stok: this.stok,
                    kategori: {
                        Id: this.categoryId
                    }
                })
                    .then(res => {
                        this.basari = true;
                        console.log(res);
                    });
                setTimeout(() => {
                    this.$router.push("/tum");
                }, 500);


            }

        }

    };

</script>
<style>

</style>