<script>
  import axios from "axios";

  export default {
    data() {
      return {
        items: [],
      };
    },
    methods: {
      editItem(itemId) {
        document.getElementById("currentId").value = itemId;
        window.location = "#/edit";
      },
      deleteItem(itemId) {
        axios.delete('http://localhost:5000/knights/' + itemId).then((response) => {
          this.items = response.data;
        });

        axios.get('http://localhost:5000/knights').then((response) => {
          this.items = response.data;
        });
      },
    },
    mounted() {

      axios.get('http://localhost:5000/knights').then((response) => {
        this.items = response.data;
      });
    },
  };
</script>

<template>
  <div class="greetings">
    <h2>Knights list:</h2>
    <div style="font-weight: bold;">Nome - Idade - Armas - Atributo - Ataque - Exp</div>
    <ul>
      <li v-for="item in items" :key="item.id">
        {{ item.nome }} -
        {{ item.idade }} -
        {{ item.armas }} -
        {{ item.atributo }} -
        {{ item.ataque }} -
        {{ item.exp }} -
        <button @click="editItem(item.id)">Edit</button>
        <button @click="deleteItem(item.id)">Delete</button>
      </li>
    </ul>
  </div>
</template>

<style scoped>
  h1 {
    font-weight: 500;
    font-size: 2.6rem;
    position: relative;
    top: -10px;
  }

  h3 {
    font-size: 1.2rem;
  }

  .greetings h1,
  .greetings h3 {
    text-align: center;
  }

  @media (min-width: 1024px) {
    .greetings h1,
    .greetings h3 {
      text-align: left;
    }
  }
</style>
