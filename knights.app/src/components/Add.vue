<template>
  <div>
    <h2>Add New Knight</h2>
    <form @submit.prevent="addItem">
      <label for="itemname">Name: </label>
      <input type="text" id="itemname" v-model="newitemname" required /><br />

      <label for="itemnickname">Nickname: </label>
      <input type="text" id="itemnickname" v-model="newitemnickname" required /><br />

      <label for="itembirthday">Birthday: </label>
      <input type="date" id="itembirthday" v-model="newitembirthday" required /><br />

      <label for="itemkeyAttribute">Key Attr: </label>
      <select id="itemkeyAttribute" v-model="newitemkeyAttribute" required>
        <option value="strength">strength</option>
        <option value="dexterity">dexterity</option>
        <option value="constitution">constitution</option>
        <option value="intelligence">intelligence</option>
        <option value="wisdom">wisdom</option>
        <option value="charisma">charisma</option>
      </select><br />
      <h2>Attributes:</h2>

      <label for="attrstrength">Strength: </label>
      <input type="text" id="attrstrength" v-model="newattrstrength" required /><br />

      <label for="attrdexterity">dexterity: </label>
      <input type="text" id="attrdexterity" v-model="newattrdexterity" required /><br />

      <label for="attrconstitution">constitution: </label>
      <input type="text" id="attrconstitution" v-model="newattrconstitution" required /><br />

      <label for="attrintelligence">intelligence: </label>
      <input type="text" id="attrintelligence" v-model="newattrintelligence" required /><br />

      <label for="attrwisdom">wisdom: </label>
      <input type="text" id="attrwisdom" v-model="newattrwisdom" required /><br />

      <label for="attrcharisma">charisma: </label>
      <input type="text" id="attrcharisma" v-model="newattrcharisma" required /><br />

      <h2>Weapon:</h2>

      <label for="weaponname">name: </label>
      <input type="text" id="weaponname" v-model="newweaponname" required /><br />

      <label for="weaponmod">mod: </label>
      <input type="text" id="weaponmod" v-model="newweaponmod" required /><br />

      <label for="weaponattr">attribute: </label>
      <select id="weaponattr" v-model="newweaponattr" required>
        <option value="strength">strength</option>
        <option value="dexterity">dexterity</option>
        <option value="constitution">constitution</option>
        <option value="intelligence">intelligence</option>
        <option value="wisdom">wisdom</option>
        <option value="charisma">charisma</option>
      </select><br />

      <label for="weaponequipped">equipped: </label>
      <input type="checkbox" id="weaponequipped" v-model="newweaponequipped" /><br />

      <button type="submit">Add Item</button>
    </form>
  </div>
</template>

<script>

  import axios from "axios";
  export default {
    data() {
      return {
        newitemname: '',
        newitemnickname: '',
        newitembirthday: '',
        newitemkeyAttribute: '',
        newattrstrength: '',
        newattrdexterity: '',
        newattrconstitution: '',
        newattrintelligence: '',
        newattrwisdom: '',
        newattrcharisma: '',
        newweaponname: '',
        newweaponmod: '',
        newweaponattr: '',
        newweaponequipped: true
      };
    },
    methods: {
      addItem() {
        axios.post('http://localhost:5000/knights/', {
          name: this.newitemname,
          nickname: this.newitemnickname,
          birthday: this.newitembirthday,
          keyAttribute: this.newitemkeyAttribute,
          attributes: {
            strength: this.newattrstrength,
            dexterity: this.newattrdexterity,
            constitution: this.newattrconstitution,
            intelligence: this.newattrintelligence,
            wisdom: this.newattrwisdom,
            charisma: this.newattrcharisma
          },
          weapons: [
            {
              name: this.newweaponname,
              mod: this.newweaponmod,
              attr: this.newweaponattr,
              equipped: this.newweaponequipped
            }
          ]
        }).then((response) => {
          alert('sucess');
          window.location = "#/";
        });
      },
    },
  };
</script>
