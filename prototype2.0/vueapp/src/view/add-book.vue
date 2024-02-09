<template>
    <div class="container">
        <br />
        <label for="c" required>cihaz adi</label>
        <input type="text" v-model="CihazAdi" id="c" class="form-control" placeholder="cihaz adi" />

        <label for="b" required>fiyat</label>
        <input type="number" id="b" v-model="fiyat" class="form-control" placeholder="cihaz fiyati" />

        <label for="b" required>serin no</label>
        <input type="number" id="b" v-model="serino" class="form-control" placeholder="cihaz seri no" />

        <label for="a" required>stok</label>
        <input type="number" v-model="stok" id="a" class="form-control" placeholder="cihaz stok" />

        <label for="q" required>ozellik</label>
        <input type="text" v-model="ozellik" id="q" class="form-control" placeholder="ozellik" />

        <label for="q" required>resim</label>
        <input type="text"  v-model="resim" id="q" class="form-control" placeholder="resim" />

        <!--<input type="file" value="" v-model="resim" id="q" class="form-control" placeholder="resim" />-->


        <label for="den" required>kategoriler</label>
        <div class="col-sm-12">
            <select class="form-select" id="den" v-model="categoryId">
                <option v-for="sec in kat" v-bind:value="sec.id">{{sec.kategoriAdi}}</option>
            </select>
            <hr />

            <button v-on:click="add" type="submit" class="btn btn-success"> cihaz ekle</button>
            <button v-on:click="goToAbout" type="submit" class="btn btn-danger" style="margin-left:3%;"> vazgec</button>
        </div>
    </div>
</template>
<script>
    import axios from "axios";
    import Swal from "sweetalert2";
    export default {
        data() {
            return {
                kitap: [],
                kat: [],
                CihazAdi: "",
                ozellikler: "",
                fiyat: 0,
                stok: 0,
                categoryId: 0,
                Id: 0,
                basari: false,
                bos: false,
                depolama: 0,
                ram: 0,
                garantisuresi: 0,
                pil: "",
                ek: "",
                resim: "",
                file: "",
                serino:0
            }; 
        },
        created: function () {
            axios.get("https://localhost:7132/api/deneme/h").then(res => {
                this.kat = res.data
                console.log("kategori",this.kat)

            });
        },
        methods: {
            goToAbout() {
                window.location.assign("/");
            },
            add: function () {
                if (this.CihazAdi != "" && this.categoryId != 0 && this.fiyat != 0) {
                    axios.post("https://localhost:7132/api/deneme/e", {
                        CihazAdi: this.CihazAdi,
                        fiyat: this.fiyat,
                        serino:this.serino,
                        stok: this.stok,
                        ozellik: this.ozellik,
                        resim: this.resim,
                        durum: "bekleme",
                        kategori: {
                            Id: this.categoryId
                        }
                    })
                        .then(res => {
                            Swal.fire({
                                icon: 'success',
                                title: 'cihaz basari ile eklendi',
                                confirmButtonText: 'Great!',
                            }).then(() => {
                                // Sayfayý yenile
                                window.location.assign("/")
                            });
                            console.log(this.resim);
                        });

                }

                if (this.CihazAdi == "" && this.categoryId != 0 && this.fiyat != 0) {
                    Swal.fire({
                        icon: 'error',
                        title: 'lutfen cihaz adi kismini doldurun',
                        confirmButtonText: 'tamam!',
                    }).then(() => {
                        // Sayfayý yenile

                    });
                }
                else if (this.CihazAdi != "" && this.categoryId == 0 && this.fiyat != 0) {
                    Swal.fire({
                        icon: 'error',
                        title: 'lutfen kategori secimi yapýn',
                        confirmButtonText: 'tamam!',
                    }).then(() => {
                        // Sayfayý yenile

                    });
                }
                else if (this.CihazAdi != "" && this.categoryId != 0 && this.fiyat == 0) {
                    Swal.fire({
                        icon: 'error',
                        title: 'lutfen fiyat bilgisi girin',
                        confirmButtonText: 'tamam!',
                    }).then(() => {
                        // Sayfayý yenile

                    });
                }
                else if (this.CihazAdi == "" && this.categoryId == 0 && this.fiyat == 0) {
                    Swal.fire({
                        icon: 'error',
                        title: 'lutfen cihaz adi,kategori ve fiyat kisimlarini doldurun',
                        confirmButtonText: 'tamam!',
                    }).then(() => {
                        // Sayfayý yenile

                    });
                }



            }

        }

    };
</script>
<style>
    @import '~bootstrap/dist/css/bootstrap.css';
</style>