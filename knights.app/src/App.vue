<script setup lang="ts">
import { ref, computed } from 'vue'
import List from './components/List.vue'
import Edit from './components/Edit.vue'
import Add from './components/Add.vue'
import Delete from './components/Delete.vue'

const routes = {
  '/': List,
  '/list': List,
  '/edit': Edit,
  '/add': Add,
  '/delete': Delete
}

const currentPath = ref(window.location.hash)

window.addEventListener('hashchange', () => {
  currentPath.value = window.location.hash
})

const currentView = computed(() => {
  return routes[currentPath.value.slice(1) || '/'] || NotFound
})
</script>

<template>
  <a href="#/">Home</a>
  <a href="#/add">Add</a>
  <input type="hidden" id="currentId" />
  <component :is="currentView" />
</template>

<style scoped>

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    flex-wrap: wrap;
    place-items: flex-start;
  }
}
</style>
