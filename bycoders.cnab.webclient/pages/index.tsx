import useSWR, { useSWRConfig } from "swr";
import axios from "axios";
import { useState } from "react";
import { BASE_URL } from "../constants/routes";
import { jsonFetcher } from "../utils/fetcher.utils";
import { DisplayStores } from "../components/display";
import { UploadFile } from "../components/upload";

export default function Index() {
  const CNAB_URL = `${BASE_URL}CNABOperations`;
  
  const { mutate } = useSWRConfig();
  const { data, error, isLoading } = useSWR(CNAB_URL, jsonFetcher);

  const [file, setFile] = useState();
  const [fileMessage, setFileMessage] = useState("");

  const saveFile = (e) => {
    setFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    setFileMessage("");

    const formData = new FormData();
    formData.append("formFile", file);

    try {
      const result = await axios.post(CNAB_URL, formData);

      if (result.status === 200) {
        mutate(CNAB_URL);
      }

      setFileMessage("Arquivo enviado com sucesso!")

    } catch (error) {
      setFileMessage("Houve um erro ao realizar o upload");
    }
  };

  if (error) return <div>Não foi possível buscar os registros</div>;
  if (isLoading) return <div>Carregando...</div>;
  if (!data) return null;

  return (
    <>
      <UploadFile handleUpload={handleUpload} saveFile={saveFile} />

      {fileMessage && <div className="display-message">{fileMessage}</div>}

      <DisplayStores stores={data} />
    </>
  );
}
