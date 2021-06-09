<template>
  <div>
    <div class="d-flex justify-content-between ">
      <h3>Bakiye: {{ amount }}</h3>
      <h3>Team Size Required: 10</h3>
      <h3>Team Size: {{ teamSize }}</h3>
    </div>
    <div class="row">
      <div class="table-responsive card col-md-6">
        <table class="table card-table ">
          <thead>
            <tr>
              <th>Name</th>
              <th>Age</th>
              <th>Position</th>
              <th>Price</th>
              <th>Add</th>
            </tr>
          </thead>
          <tbody v-for="(item, index) in contents" :key="index">
            <tr>
              <td>{{ item.name }}</td>
              <td>{{ item.age }}</td>
              <td>{{ item.position }}</td>
              <td>{{ item.pirValue }}</td>
              <td>
                <button
                  @click="addtoRightContent(item)"
                  type="button"
                  class="btn btn-sm  btn-primary"
                >
                  ADD
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="card col-md-5 ml-5">
        <table class="table card-table ">
          <thead>
            <tr>
              <th>DEL</th>
              <th>Name</th>
              <th>Age</th>
              <th>Position</th>
              <button
                @click="savetoTeam(players)"
                type="button"
                class="btn btn btn-success mt-1 "
              >
                SAVE
              </button>
            </tr>
          </thead>
          <tbody v-for="(item, index) in rightContent" :key="index">
            <tr>
              <td>
                <button
                  @click="deltoRightContent(item)"
                  type="button"
                  class="btn btn-danger btn-sm btn-success"
                >
                  <icon icon="minus" />
                </button>
              </td>
              <td>{{ item.name }}</td>
              <td>{{ item.age }}</td>
              <td>{{ item.position }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>


<script>
import Vue from "vue";
import service from "../../../services/content";
import router from "@/router";
export default {
  data() {
    return {
      contents: [],
      rightContent: [],
      players: [],
      amount: 250000,
      teamSize: 0
    };
  },
  async mounted() {
    var result = await service.fixture();
    if (result.data && result.data.length) {
      this.contents.push(...result.data);
    }
    console.log(result);
  },
  methods: {
    addtoRightContent(item) {
      var cLength = this.rightContent.length;
      var balance = this.amount;
      if (balance > item.pirValue) {
        if (cLength < 10) {
          console.log(cLength);
          console.log(item.basketballerId);
          var index = this.contents.findIndex(
            x => x.basketballerId === item.basketballerId
          );
          var basketballer = this.contents.splice(index, 1);
          this.rightContent.push(basketballer[0]);
          this.teamSize++;
          this.amount -= item.pirValue;
        } else {
          Vue.notify({
            title: "Error",
            text: "The team must consist of 10 people",
            type: "error",
            duration: 7000
          });
        }
      } else {
        Vue.notify({
          title: "Error",
          text: "Insufficient balance.",
          type: "error",
          duration: 7000
        });
      }
    },
    deltoRightContent(item) {
      var index = this.rightContent.findIndex(
        x => x.basketballerId === item.basketballerId
      );
      var basketballer = this.rightContent.splice(index, 1);
      this.amount += item.pirValue;
      this.teamSize--;
      this.contents.push(basketballer[0]);
    },
    async savetoTeam(players) {
      if (this.teamSize === 10) {
        let result = await service.teamSave(this.rightContent);
        if (result.success) {
          router.push({
            name: "home-page"
          });
        }
      } else {
        Vue.notify({
          title: "Error",
          text: "To save the team, their number must be 10.",
          type: "error",
          duration: 7000
        });
      }
    }
  }
};
</script>
