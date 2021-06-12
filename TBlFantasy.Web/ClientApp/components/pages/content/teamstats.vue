<template>
  <div>
    <page-head icon="basketball-ball" title="Fixture" />
    <div class="row d-flex justify-content-between">
      <div class="table-responsive card ">
        <table class="table card-table ">
          <thead>
            <tr>
              <th>Name</th>
              <th>Points</th>
              <th>Assists</th>
              <th>Rebounds</th>
              <th>Blocks</th>
              <th>Steals</th>
              <th>Turnovers</th>
              <th>Two Point Shot</th>
              <th>Three Point Shot</th>
              <th>Free Thrown</th>
            </tr>
          </thead>
          <tbody v-for="(item, index) in teamPlayers" :key="index">
            <tr>
              <td>{{ item.name }}</td>
              <td>{{ item.points }}</td>
              <td>{{ item.assists }}</td>
              <td>{{ item.rebounds }}</td>
              <td>{{ item.blocks }}</td>
              <td>{{ item.steals }}</td>
              <td>{{ item.turnovers }}</td>
              <td>{{ item.twoPoint }}</td>
              <td>{{ item.threePoint }}</td>
              <td>{{ item.freeThrown }}</td>
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
      teamPlayers: []
    };
  },
  async mounted() {
    let result = await service.playerGet();
    if (result.data && result.data.length) {
      this.teamPlayers.push(...result.data);
    }
    console.log(result);
  }
};
</script>
