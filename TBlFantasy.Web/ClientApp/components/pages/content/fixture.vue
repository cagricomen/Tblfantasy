<template>
  <div>
    <page-head icon="basketball-ball" title="Fixture" />
    <div class="d-flex justify-content-between ">
      <h3 class="text-primary">TBLFANTASY LEAGUE STANDINGS</h3>
      <h3 class=" text-primary mr-3">FIXTURE</h3>
      <h3></h3>
    </div>
    <div class="row d-flex justify-content-between">
      <div class="table-responsive card col-md-6">
        <table class="table card-table ">
          <thead>
            <tr>
              <th>#</th>
              <th>Team</th>
              <th>T</th>
              <th>W</th>
              <th>L</th>
              <th>P</th>
            </tr>
          </thead>
          <tbody v-for="(item, index) in contents" :key="index">
            <tr>
              <td>{{ index + 1 }}</td>
              <td>{{ item.name }}</td>
              <td>{{ item.gamesPlayed }}</td>
              <td>{{ item.win }}</td>
              <td>{{ item.lose }}</td>
              <td>{{ item.points }}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="table-responsive card col-5 mr-5">
        <table class="table card-table ">
          <thead>
            <tr>
              <th>Week</th>
              <th>Home Team</th>
              <th>P</th>
              <th>Away Team</th>
              <th>P</th>
              <th>Winner</th>
            </tr>
          </thead>
          <tbody v-for="(item, index) in matches" :key="index">
            <tr>
              <td>{{ item.week}}</td>
              <td> {{item.userTeam}}</td>
              <td>{{ item.userScore}}</td>
              <td>{{  item.fakeTeam}}</td>
              <td>{{ item.fakeScore}}</td>
              <td class="text-danger">{{item.winner}}</td>
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
      contents: [],
      matches: []
    };
  },
  async mounted() {
    var result = await service.teams();
    if (result.data && result.data.length) {
      this.contents.push(...result.data);
    }
    var fixture = await service.teamGet();
    console.log(fixture);
    if (fixture.data && fixture.data.length) {
      this.matches.push(...fixture.data);
    }


  }
};
</script>

<style>
</style>
