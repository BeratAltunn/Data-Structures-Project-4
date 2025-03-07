import networkx as nx
import matplotlib.pyplot as plt

# Aile üyelerini ve ilişkilerini tanımlayalım
nodes = {
    "Olivia": {},
    "Celine": {},
    "John": {},
    "Chloe": {},
    "Jack": {},
    "Winston": {},
}

edges = [
    ("Olivia", "Celine", {"weight": 8}),
    ("Olivia", "John", {"weight": 7}),
    ("Olivia", "Jack", {"weight": 4}),
    ("Celine", "Jack", {"weight": 5}),
    ("Celine", "Winston", {"weight": 6}),
    ("John", "Chloe", {"weight": 7}),
    ("John", "Jack", {"weight": 9}),
    ("Jack", "Chloe", {"weight": 5}),
    ("Chloe", "Winston", {"weight": 11}),
    ("Jack", "Winston", {"weight": 7}),
]

# Aile ağacı grafiğini oluşturalım
G = nx.Graph()
G.add_nodes_from(nodes)
G.add_edges_from(edges)
# Her kişi çifti için en kısa yolu hesaplayalım
for person1 in nodes:
    for person2 in nodes:
        if person1 != person2:
            shortest_path = nx.dijkstra_path(G, source=person1, target=person2)
            shortest_distance = nx.dijkstra_path_length(G, source=person1, target=person2)
            print(f"En kısa yol {person1} ile {person2} arasında: {shortest_path}, Uzaklık: {shortest_distance}")
# DFS dolaşımı
start_node_dfs = "Olivia"
dfs_traversal = list(nx.dfs_edges(G, source=start_node_dfs))
print(f"DFS Dolaşımı ({start_node_dfs} başlangıç noktasıyla): {dfs_traversal}")

# BFS dolaşımı
start_node_bfs = "Olivia"
bfs_traversal = list(nx.bfs_edges(G, source=start_node_bfs))
print(f"BFS Dolaşımı ({start_node_bfs} başlangıç noktasıyla): {bfs_traversal}")



# Aile ağacı grafiğini görselleştirelim
pos = nx.spring_layout(G)  # Düğümleri yerleştirmek için yaygın bir algoritma
nx.draw(G, pos, with_labels=True)
labels = nx.get_edge_attributes(G, 'weight')
nx.draw_networkx_edge_labels(G, pos, edge_labels=labels)
plt.show()

