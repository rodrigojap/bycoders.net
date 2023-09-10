import useSWR, { useSWRConfig } from 'swr'
import axios from "axios";
import { useState } from "react";
import { BASE_URL } from "../constants/routes";
import { jsonFetcher } from "../utils/fetcher.utils";
import { DisplayStores } from "../components/display";
import { UploadFile } from "../components/upload";

export default function Index() {
  const { mutate } = useSWRConfig()
  const { data, error, isLoading } = useSWR(
    `${BASE_URL}CNABOperations`,
    jsonFetcher
  );

  const [file, setFile] = useState();
  const [fileError, setFileError] = useState('');

  const saveFile = (e) => {
    setFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    setFileError('')

    const formData = new FormData();
    formData.append("formFile", file);

    try {
      const result = await axios.post(`${BASE_URL}CNABOperations`, formData);

      if (result.status === 200) {
        mutate(`${BASE_URL}CNABOperations`);
      }

    } catch (error) {
      setFileError("Houve um erro ao realziar o upload")
    }
  };

  if (error) return <div>Não foi possível buscar os registros</div>;
  if (isLoading) return <div>Carregando...</div>;
  if (!data) return null;

  return (
    <>
      <UploadFile handleUpload={handleUpload} saveFile={saveFile} />
      
      {fileError && <div>{fileError}</div>}

      <DisplayStores stores={data} />
    </>
  );
}
