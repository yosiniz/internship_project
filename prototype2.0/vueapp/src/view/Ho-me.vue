<template>
    <AppHeader />
    <div class="flex flex-row">
        <Sidebar />

        <app-bookmark-list></app-bookmark-list>

    </div>
</template>
<script>
    import Sidebar from "@/components/home/sidebar"
    export default {
        //        created() {
        //    window.addEventListener('beforeunload', () => {
        //        this.$store.commit("engelle");
        //    })
        //},
        components: {
            Sidebar
        }
    };


</script>
<style>
</style>