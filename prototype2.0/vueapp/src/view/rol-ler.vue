<template>
    <side-bar2 />
    <div class="flex flex-row" style="width:100%;">
        <Sidebar />
        <div style="width:100%;">
            
            <div style="width: 24%; margin-top: 5%; display: inline-block; margin-left: 6.3%; border-bottom:2px solid black; text-align:center;"> admin</div>

            <div style="width: 24%; margin-top: 5%; display: inline-block; margin-left: 6.3%; margin-right: 6.3%; float: right; border-bottom: 2px solid black; text-align: center; ">yonetici</div>

            <div style="width: 24%; margin-top: 5%; display: inline-block; margin-left: 6.3%; float: right; border-bottom: 2px solid black; text-align: center; ">okur</div>

        </div>

    </div>
</template>
<script>
    import Sidebar from "@/components/home/sidebar"
    import sideBar2 from "@/components/Account/acheader";
    export default {
        data() {

        },
        components: {
            Sidebar,
            sideBar2
        },
    }
</script>
<style>

</style>