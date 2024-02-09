import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";
import SecureLS from "secure-ls";
var ls = new SecureLS({ isCompression: false });


export default new Vuex.Store({
    state: {
        giris: false,
        user: null,
        rol: "",
        id: null,
        mail: null

    },
    mutations: {
        engelle(state) {
            state.giris = false;

        },
        ac(state) {
            state.giris = true;
        },
        rolal(state,roll) {
            state.rol = roll;
        },
        mailal(state, email) {
            state.mail = email;
        },
        iddegis(state, id) {
            state.id = id;
        },
        idreset(state,) {
            state.id = null;
        }
    },
    actions: {
    },
    getters: {
        girdimi: state => state.giris,
        rolne: state => state.rol,
        mailne:state=>state.mail,
        idne:state=>state.id,
        getUser(state) {
            const user = state.giris;
            return user;
        },
        _getuser(state) {
            const user = state.user;
            delete user?.psifre;
            return user;
        }

    },
    modules: {
    },
    plugins: [createPersistedState({
        storage: {
            getItem: (key) => ls.get(key),
            setItem: (key, value) => ls.set(key, value),
            removeItem: (key) => ls.remove(key),
        },
    }),
    ],

})