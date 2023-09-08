import useSWR from "swr";
import axios from "axios";
import { useState } from "react";

const fetcher = (url: string) => fetch(url).then((res) => res.json());

export default function Index() {
  const { data, error, isLoading } = useSWR(
    "http://localhost:5001/api/CNABOperations",
    fetcher
  );
  const [file, setFile] = useState();

  const saveFile = (e) => {
    console.log(e);
    setFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    const formData = new FormData();
    formData.append("formFile", file);

    try {
      const res = await axios.post(
        "http://localhost:5001/api/CNABOperations",
        formData
      );
    } catch (error) {}
  };

  if (error) return <div>Failed to load</div>;
  if (isLoading) return <div>Loading...</div>;
  if (!data) return null;

  return (
    <ul>
      <input type="file" onChange={saveFile}></input>
      <input
        type="button"
        value="upload"
        onClick={() => handleUpload()}
      ></input>
    </ul>
  );
}
