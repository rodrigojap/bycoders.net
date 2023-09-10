import useSWR from "swr";
import axios from "axios";
import { useState } from "react";
import { BASE_URL } from "../constants/routes";
import { jsonFetcher } from "../utils/fetcher.utils";
import { DisplayStores } from "../components/display";
import { UploadFile } from "../components/upload";

export default function Index() {
  const { data, error, isLoading } = useSWR(
    `${BASE_URL}CNABOperations`,
    jsonFetcher
  );

  const [file, setFile] = useState();

  const saveFile = (e) => {
    setFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    const formData = new FormData();
    formData.append("formFile", file);

    try {
      await axios.post(`${BASE_URL}CNABOperations`, formData);
    } catch (error) {}
  };

  if (error) return <div>Não foi possível buscar os registros</div>;
  if (isLoading) return <div>Carregando...</div>;
  if (!data) return null;

  return (
    <>
      <UploadFile handleUpload={handleUpload} saveFile={saveFile} />
      <DisplayStores stores={data} />
    </>
  );
}
