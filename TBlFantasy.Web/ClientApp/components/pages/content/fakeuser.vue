<template>
  <div>
    <page-head icon="basketball-ball" title="Fixture" />
    <div class="d-flex justify-content-between ">
      <h3 class=" text-primary mr-3"> ALL FIXTURE</h3>
      <h3></h3>
    </div>
    <div class="row d-flex justify-content-between">
      <div class="table-responsive card">
        <table class="table card-table table-bordered border-light table-primary ">
          <thead class="table-primary">
            <tr>
              <th>Week</th>
              <th>Home Team</th>
              <th>P</th>
              <th>Away Team</th>
              <th>P</th>
              <th>Winner</th>
            </tr>
          </thead>
          <tbody v-for="(item, index) in allFixture" :key="index">
            <tr>
              <td >{{ item.week }}</td>
              <td>{{ item.userTeam }}</td>
              <td>{{ item.userScore }}</td>
              <td>{{ item.fakeTeam }}</td>
              <td>{{ item.fakeScore }}</td>
              <td >{{ item.winner }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import service from "../../../services/content";
export default {
  data() {
    return {
      allFixture: []
    };
  },
  async mounted() {
    let result = await service.fakeGet();
    if (result.data && result.data.length) {
      this.allFixture.push(...result.data);
    }
    console.log(result);
  }
};
</script>
