import { createRouter, createWebHistory } from "vue-router";
import store from "./store"

const routes = [
    {
        name: "HomePage",
        path: "/",
        component: () => import("@/view/Ho-me")
    },
    {
        name: "LoginPage",
        path: "/log",
        component: () => import("@/view/log-in")
    },
    {
        name: "addbook",
        path: "/adbk",
        component: () => import("@/view/add-book")
    },
    {
        name: "edit",
        path: "/edt",
        component: () => import("@/view/edit-book")
    },
    {
        name: "Account",
        path: "/fav",
        component: () => import("@/view/ac-count")
    },
    {
        name: "setting",
        path: "/set",
        component: () => import("@/view/ac-count")
    },
    {
        name: "kulgor",
        path: "/kg",
        component: () => import("@/view/kullanici-goruntule")
    },
    {
        name: "kulek",
        path: "/ke",
        component: () => import("@/view/kullanici-ekle")
    },
    {
        name: "rol",
        path: "/r",
        component: () => import("@/view/rol-ler")
    },
    {
        name: "kategori",
        path: "/ktg",
        component: () => import("@/view/kategori-goruntule")
    },
    {
        name: "hesap",
        path: "/hp",
        component: () => import("@/view/hes-ap")
    },


];

const router = createRouter({
    routes,
    history: createWebHistory()
});
router.beforeEach((to, _, next) => {
    const auth = ["HomePage", "addbook", "edit", "setting","Account"];
    const auth2 = ["addbook", "edit"];
    const AuthEngel = ["LoginPage"];
    const girdimi = store.getters.girdimi;
    const rol = store.getters.rolne;

    if (auth2.indexOf(to.name) > -1 && rol=="okur") next({ name: "HomePage" });

    if (AuthEngel.indexOf(to.name) > -1 && girdimi) next({ name: "HomePage" });
    if (auth.indexOf(to.name) > - 1) {
        if (girdimi) next();
        else next({ name: "LoginPage"});
    }
    else {
        next();
    }
});

export default router; 