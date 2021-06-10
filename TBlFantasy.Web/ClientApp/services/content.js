import { http } from '../utils/http';

const ContentService = {
  async fixture() {
    var result = await http.get("/api/basketballer");
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  },
  async teams() {
    var result = await http.get("/api/team");
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  },
  async teamMatch(id) {
    var result = await http.get("/api/team/score-history"+id);
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  },

  async save(value) {
    var result = await http.post("/api/basketballer", value);
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  },
  async teamSave(value) {
    var result = await http.post("/api/team", value);
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  },
  async teamGet(id) {
    var result = await http.get("/api/team/teamstats/" + id);
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  },
  async fakeGet() {
    var result = await http.get("/api/fake");
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  }
}
export default ContentService;
