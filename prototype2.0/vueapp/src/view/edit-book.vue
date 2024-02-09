<template>
    <div v-for="kit in kitap2" class="container">
        <br />
        <label for="c" required>kitap adi</label>
        <input type="text" v-model="CihazAdi" id="c" class="form-control" :placeholder="kit.cihazAdi" />


        <label for="b" required>fiyat</label>
        <input type="number" id="b" v-model="fiyat" class="form-control" :placeholder="kit.fiyat" />

        <label for="b" required>serin no</label>
        <input type="number" id="b" v-model="serino" class="form-control" :placeholder="kit.serino" />

        <label for="a" required>stok</label>
        <input type="number" v-model="stok" id="a" class="form-control" :placeholder="kit.stok" />

        <label for="q" required>ozellik</label>
        <input type="text"  v-model="ozellik" id="q" class="form-control" :placeholder="kit.ozellik" />

        <label for="q" required>resim</label>
        <input style="cursor: not-allowed;" type="text" v-model="resim" id="q" class="form-control" :placeholder="kit.durum" DISABLED/>

        <label for="q" required>durum</label>
        <input type="text"  v-model="resim" id="q" class="form-control" :placeholder="kit.resim" />

        <!--<input type="file" value="" v-model="resim" id="q" class="form-control" placeholder="resim" />-->


        <label for="den" required>kategoriler</label>
        <div class="col-sm-12">
            <select class="form-select" id="den" v-model="categoryId">
                <option v-for="sec in kat" v-bind:value="sec.id">{{sec.kategoriAdi}}</option>
            </select>
            <hr />
            <button v-on:click="ekle" type="submit" class="btn btn-success"> kitabi ekle</button>
            <button v-on:click="goToAbout" type="submit" class="btn btn-danger" style="margin-left:3%;"> vazgec</button>
        </div>
    </div>
</template>

<script>
    import { mapGetters, mapMutations } from 'vuex';
    import axios from "axios";
    import Swal from "sweetalert2";
    export default {
        computed: {
            ...mapGetters(["id"]),
        },
        data() {
            return {
                kat: [],
                kitap: [],
                kitap2: [],
                id:  this.$store.state.id, 
            }
        },

        created: function () {
            axios.get(`https://localhost:7132/api/deneme/t/${this.id}`).then(res => {
                this.kitap2 = res.data;
                console.log(this.kitap2);
            });
            axios.get("https://localhost:7132/api/deneme/h").then(res => {
                this.kat = res.data

            });
        },
        methods: {
            ...mapMutations(["idreset"]),
            goToAbout() {
                this.idreset(); 
                window.location.assign("/");
            },
            ekle() {
                axios.post("https://localhost:7132/api/deneme/edt", {
                    Id:this.id,
                    CihazAdi: this.CihazAdi,
                    fiyat: this.fiyat,
                    serino: this.serino,
                    stok: this.stok,
                    ozellik: this.ozellik,
                    resim: this.resim,
                    durum: "bekleme",
                    kategori: {
                        Id: this.categoryId
                    }
                }).then(res => {
                    Swal.fire({
                        icon: 'success',
                        title: 'kitap basari ile guncellendi',
                        confirmButtonText: 'Great!',
                    }).then(() => {
                        // Sayfayý yenile
                        window.location.assign("/")
                    });
                    console.log(this.resim);
                });
            }
        }
    }

</script>

<style>
    @import '~bootstrap/dist/css/bootstrap.css';
</style>