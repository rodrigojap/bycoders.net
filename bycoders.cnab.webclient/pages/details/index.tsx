import { useRouter } from "next/router";
import useSWR from "swr";
import { BASE_URL } from "../../constants/routes";
import { jsonFetcher } from "../../utils/fetcher.utils";
import { CNABGrid } from "../../components/grid";

export default function DetailsPage() {
  const { query, push } = useRouter();

  const { data, error, isLoading } = useSWR(
    `${BASE_URL}CNABOperations/${query.storeName}`,
    jsonFetcher
  );

  if (error) return <div>Não foi possível buscar os registros</div>;
  if (isLoading) return <div>Carregando...</div>;
  if (!data) return null;

  return (
    <>      
      <CNABGrid CNABData={data} />              
      <button onClick={() => push("/")}>Voltar</button>
    </>
  );
}
