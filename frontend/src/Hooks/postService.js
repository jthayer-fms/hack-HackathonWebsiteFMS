import axios from "axios";

const baseUrl = "https://localhost:5001/";

export async function savePitch(pitch) {
  return axios.post(baseUrl + "events", {
    headers: {"Access-Control-Allow-Origin": "*"},
    body: {
      description: pitch.description
    }
  })
}
