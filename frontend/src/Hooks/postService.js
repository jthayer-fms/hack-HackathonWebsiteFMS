import axios from "axios";

const baseUrl = "https://localhost:5001/";

export async function saveEvent(event) {
  // console.log(event, "event")
  return axios.post(baseUrl + "events", {
    headers: {"Access-Control-Allow-Origin": "*"},
    body: {
      name: event.name,
      description: event.description
    }
  })
}
