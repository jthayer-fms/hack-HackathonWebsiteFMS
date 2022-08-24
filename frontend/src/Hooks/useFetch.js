import {useState, useEffect} from 'react'
import axios from "axios";
const baseUrl = "https://localhost:5001/";

export default function useFetch(url) {
  const [data, setData] = useState(null)
  const [error, setError] = useState(null)
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    async function init() {
      try {
        console.log(baseUrl+url)
        const response = await axios.get(baseUrl + url)
        if (response.status===200){
          const json = await response.data;
          setData(json)
        }else{
          throw response;
        }
      } catch (e) {
        setError(e)
      } finally {
        setLoading(false)
      }
    }
    init()
  }, [url])
  return {data, loading, error };
}